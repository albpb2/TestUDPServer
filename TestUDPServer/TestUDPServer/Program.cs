using System;
using System.Net;
using System.Net.Sockets;
using TestUDPEntities;
using TestUDPUtils;

namespace TestUDPServer
{
    class Program
    {
        private const int listenPort = 11000;
    
        public static void Main()
        {
            StartListener();
        }
    
        private static void StartListener()
        {
            UdpClient listener = new UdpClient(listenPort);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, listenPort);
            var asyncResult = listener.BeginReceive( null, null );
            var timeToWait = TimeSpan.FromSeconds(10);
            asyncResult.AsyncWaitHandle.WaitOne( timeToWait );

            var diary = new Diary();
            
            try
            {
                while (true)
                {
                    Console.WriteLine("Waiting for broadcast");
                    
                    try
                    {
                        byte[] bytes = listener.EndReceive(asyncResult, ref groupEP);

                        var diaryEntry = SerializationUtils.FromByteArray<DiaryEntry>(bytes);
                        diary.AddEntry(diaryEntry);
                
                        Console.WriteLine($"Received broadcast from {groupEP} :");
                    
                        Console.WriteLine(diaryEntry.Text);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        
                        Console.WriteLine("DIARY CONTENT");
                        
                        Console.WriteLine();
                        
                        diary.WriteDiary();
                        
                        Console.WriteLine();
                        Console.WriteLine();
                        
                        diary = new Diary();
                    }
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                listener.Close();
            }
        }
    }
}