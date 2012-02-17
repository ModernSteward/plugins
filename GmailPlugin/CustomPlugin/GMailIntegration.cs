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

        public bool GetFeed()
        {
            mGMailFeed = new RC.Gmail.GmailAtomFeed(mUsername, mPassword);
            return mGMailFeed.GetFeed();
        }

        public int NewMessagesCount
        {
            get
            {
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
