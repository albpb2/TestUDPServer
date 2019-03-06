using System;
using ProtoBuf;

namespace TestUDPEntities
{
    [ProtoContract]
    public class DiaryEntry
    {
        [ProtoMember(1)]
        public DateTime Date { get; set; }
        [ProtoMember(2)]
        public string Text { get; set; }
    }
}