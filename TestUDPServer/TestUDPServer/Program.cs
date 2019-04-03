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

        private static bool _endProcess = false;
    
        public static void Main()
        {
            AppDomain.CurrentDomain.ProcessExit += AppDomainOnProcessExit;
            StartListener();
        }

        private static void StartListener()
        {
            UdpClient listener = new UdpClient(listenPort);
            listener.Client.ReceiveTimeout = 10000;
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, listenPort);

            var diary = new Diary();
            
            try
            {
                while (!_endProcess)
                {
                    Console.WriteLine("Waiting for broadcast");
                    
                    try
                    {
                        byte[] bytes = listener.Receive(ref groupEP);

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

        private static void AppDomainOnProcessExit(object sender, EventArgs e)
        {
            _endProcess = true;
        }
    }
}