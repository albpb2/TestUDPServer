using System;
using System.Collections.Generic;
using System.Linq;

namespace TestUDPEntities
{
    public class Diary
    {
        private readonly List<DiaryEntry> _entries;

        public Diary()
        {
            _entries = new List<DiaryEntry>();
        }

        public void AddEntry(DiaryEntry entry)
        {
            _entries.Add(entry);
        }

        public void WriteDiary()
        {
            foreach (var diaryEntry in _entries.OrderBy(e => e.Date))
            {
                Console.WriteLine(diaryEntry.Text);
            }
        }
    }
}