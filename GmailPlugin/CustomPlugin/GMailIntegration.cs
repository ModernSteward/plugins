using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using RC.Gmail;

namespace ModernSteward
{
    public class GMailIntegration
    {
        private string mUsername;
        private string mPassword;

        private GmailAtomFeed mGMailFeed;

        public GMailIntegration()
        {
        }

        public GMailIntegration(string username, string password)
        {
            this.mUsername = username;
            this.mPassword = password;
        }
        public int NewMessagesCount
        {
            get
            {
                // Create the object and get the feed 
                mGMailFeed = new RC.Gmail.GmailAtomFeed(mUsername, mPassword);
                mGMailFeed.GetFeed();

                // Access the feeds XmlDocument 
                XmlDocument myXml = mGMailFeed.FeedXml;

                // Access the raw feed as a string 
                string feedString = mGMailFeed.RawFeed;
                //Console.WriteLine(feedString);

                // Access the feed through the object 
                string feedTitle = mGMailFeed.Title;
                string feedTagline = mGMailFeed.Message;
                DateTime feedModified = mGMailFeed.Modified;
                return mGMailFeed.FeedEntries.Count;
            }
        }
        public RC.Gmail.GmailAtomFeed.AtomFeedEntryCollection Entries
        {
            get
            {
                return this.mGMailFeed.FeedEntries;
            }
        }
    }
}
