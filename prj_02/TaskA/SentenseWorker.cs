using System;
using System.Collections.Generic;

namespace TaskA
{
    class SentenseWorker
    {
        public string Text { get; private set; }
        List<string> Sentences;

        //Singleton realization
        private static SentenseWorker instance;
        private SentenseWorker(string content)
        {
            Text = content;
            Sentences = new List<string>();
        }
        public static SentenseWorker GetInstanse(string content)
        {
            if (instance == null)
            {
                instance = new SentenseWorker(content);
            }
            return instance;
        }

        protected void ChangeUpperToLower()
        {
            Text = Text.ToLower();
        }
        protected void SeparateToSentences()
        {
            Sentences.AddRange(Text.Split(new Char[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries));
            Text = string.Join(".\n", Sentences);
        }
        protected void AddCurrentTimeToEverySentence()
        {
            for (int i = 0; i<Sentences.Count; i++)
            {
                string currentTimeAndDate = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss.fff");
                Sentences[i] = string.Format("{0} {1}", currentTimeAndDate, Sentences[i]);
                Text = string.Join(".\n", Sentences);
            }
        }
        public void Do()
        {
            ChangeUpperToLower();
            SeparateToSentences();
            AddCurrentTimeToEverySentence();
        }
    }
}
