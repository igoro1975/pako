/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Pako Jabber-bot. Bbodio's Lab.                                                *
 * Copyright. All rights reserved � 2007-2008 by Klichuk Bogdan (Bbodio's Lab)   *
 * Contact information is here: http://code.google.com/p/pako                    *
 *                                                                               *
 * Pako is under GNU GPL v3 license:                                             *
 * YOU CAN SHARE THIS SOFTWARE WITH YOUR FRIEND, MAKE CHANGES, REDISTRIBUTE,     *
 * CHANGE THE SOFTWARE TO SUIT YOUR NEEDS, THE GNU GENERAL PUBLIC LICENSE IS     *
 * FREE, COPYLEFT LICENSE FOR SOFTWARE AND OTHER KINDS OF WORKS.                 *
 *                                                                               *
 * Visit http://www.gnu.org/licenses/gpl.html for more information about         *
 * GNU General Public License v3 license                                         *
 *                                                                               *
 * Download source code: http://pako.googlecode.com/svn/trunk                    *
 * See the general information here:                                             *
 * http://code.google.com/p/pako.                                                *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using System;
using System.Collections.Generic;
using System.Text;
using Core.Kernel;
using agsXMPP;
using agsXMPP.protocol.client;
using agsXMPP.Xml.Dom;

namespace Core.Xml
{
    public class Config : XMLContainer
    {

        public Config(string File)
        {
            Open(File, 17);
        }
 

         public string Nick
        {
            get
            {
                lock (Document)
                {
                    return Document.RootElement.SelectSingleElement("bot").SelectSingleElement("nick").GetAttribute("value");
                }
            }

            set
            {
                lock (Document)
                {
                     Document.RootElement.SelectSingleElement("bot").SelectSingleElement("nick").SetAttribute("value", value);
                     Save();
                }
            }

        }
        public bool AutoSubscribe
        {
            get
            {
                lock (Document)
                {
                    return Document.RootElement.SelectSingleElement("bot").SelectSingleElement("autosubscribe").GetAttributeBool("value");
                }
            }

            set
            {
                lock (Document)
                {
                    Document.RootElement.SelectSingleElement("bot").SelectSingleElement("autosubscribe").SetAttribute("value", value);
                    Save();
                }
            }

        }
        public bool Debug
        {
            get
            {
                lock (Document)
                {
                    return Document.RootElement.SelectSingleElement("bot").SelectSingleElement("debug").GetAttributeBool("value");
                }
            }

            set
            {
                lock (Document)
                {
                    Document.RootElement.SelectSingleElement("bot").SelectSingleElement("debug").SetAttribute("value", value);
                    Save();
                }
            }

        }
         public string ConnectServer
         {
             get
             {
                 lock (Document)
                 {
                     return  Document.RootElement.SelectSingleElement("bot").SelectSingleElement("connect_server").GetAttribute("value");
                 }
             }

             set
             {
                 lock (Document)
                 {
                     Document.RootElement.SelectSingleElement("bot").SelectSingleElement("connect_server").SetAttribute("value", value);
                     Save();
                 }
             }

         }


        public Jid Jid
        {
            get
            {
                lock (Document)
                {
                    return  new Jid(Document.RootElement.SelectSingleElement("bot").SelectSingleElement("jid").GetAttribute("value"));
                }
            }

            set
            {
                lock (Document)
                {
                    Document.RootElement.SelectSingleElement("bot").SelectSingleElement("jid").SetAttribute("value", value.ToString());
                    Save();
                }
            }

        }




        public string Password
        {
            get
            {
                lock (Document)
                {
                    return Document.RootElement.SelectSingleElement("bot").SelectSingleElement("password").GetAttribute("value");
                }
            }

            set
            {
                lock (Document)
                {
                    Document.RootElement.SelectSingleElement("bot").SelectSingleElement("password").SetAttribute("value", value);
                    Save();
                }
            }

        }



        public string Delimiter
        {
            get
            {
                lock (Document)
                {
                    return Document.RootElement.SelectSingleElement("bot").SelectSingleElement("prefix").GetAttribute("value");
                }
            }

            set
            {
                lock (Document)
                {
                    Document.RootElement.SelectSingleElement("bot").SelectSingleElement("prefix").SetAttribute("value", value);
                    Save();
                }
            }

        }


        public string Status
        {
            get
            {
                lock (Document)
                {
                    return Document.RootElement.SelectSingleElement("bot").SelectSingleElement("status").GetAttribute("value");
                }
            }

            set
            {
                lock (Document)
                {
                    Document.RootElement.SelectSingleElement("bot").SelectSingleElement("status").SetAttribute("value", value);
                    Save();
                }
            }

        }

        public List<Jid> Administartion()
        {
            lock (Document)
            {
                List<Jid> jids_set = new List<Jid>();
                foreach (string jid in Document.RootElement.SelectSingleElement("bot").SelectSingleElement("admins").GetAttribute("value").Split(' '))
                {
                    jids_set.Add(new Jid((new Jid(jid.ToLower())).Bare));
                }
                return jids_set;
            }
        }

        public bool BotAdmin(Jid Jid)
        {
            lock (Document)
            {
                if (Jid == null)
                    return false;
                else
                {
                    foreach (Jid j in this.Administartion())
                    {
                        if (j.Bare.ToLower() == Jid.Bare.ToLower())
                            return true;
                    }
                    return false;
                }
            }
        }


        public int MucMSGLimit
        {
            get
            {
                lock (Document)
                {
                    return Document.RootElement.SelectSingleElement("bot").SelectSingleElement("mucmsglimit").GetAttributeInt("value");
                }
            }

            set
            {
                lock (Document)
                {
                    Document.RootElement.SelectSingleElement("bot").SelectSingleElement("mucmsglimit").SetAttribute("value", value);
                    Save();
                }
            }

        }


        public bool UseSSL
        {
            get
            {
                lock (Document)
                {
                    return  Document.RootElement.SelectSingleElement("bot").SelectSingleElement("ssl").GetAttributeBool("value");
                }
            }

            set
            {
                lock (Document)
                {
                    Document.RootElement.SelectSingleElement("bot").SelectSingleElement("ssl").SetAttribute("value", value.ToString());
                    Save();
                }
            }

        }

        public bool UseCompression
        {
            get
            {
                lock (Document)
                {
                    return Document.RootElement.SelectSingleElement("bot").SelectSingleElement("compression").GetAttributeBool("value");
                }
            }

            set
            {
                lock (Document)
                {
                    Document.RootElement.SelectSingleElement("bot").SelectSingleElement("compression").SetAttribute("value", value.ToString());
                    Save();
                }
            }

        }


        public bool UseStartTls
        {
            get
            {
                lock (Document)
                {
                    return Document.RootElement.SelectSingleElement("bot").SelectSingleElement("starttls").GetAttributeBool("value");
                }
            }

            set
            {
                lock (Document)
                {
                    Document.RootElement.SelectSingleElement("bot").SelectSingleElement("starttls").SetAttribute("value", value.ToString());
                    Save();
                }
            }

        }


        public int ReconnectTime
        {
            get
            {
                lock (Document)
                {
                    return Document.RootElement.SelectSingleElement("bot").SelectSingleElement("reconnect_time").GetAttributeInt("value");
                }
            }

            set
            {
                lock (Document)
                {
                    Document.RootElement.SelectSingleElement("bot").SelectSingleElement("reconnect_time").SetAttribute("value", value);
                    Save();
                }
            }

        }

 public int RecursionLevel
        {
            get
            {
                lock (Document)
                {
                    int level =  Document.RootElement.SelectSingleElement("bot").SelectSingleElement("recursion_level").GetAttributeInt("value");
		    return level < 1 ? 1 : level;
                }
            }

            set
            {
                lock (Document)
                {
                    Document.RootElement.SelectSingleElement("bot").SelectSingleElement("recursion_level").SetAttribute("value", value);
                    Save();
                }
            }

        }
        public int MaxReconnects
        {
            get
            {
                lock (Document)
                {
                    return Document.RootElement.SelectSingleElement("bot").SelectSingleElement("max_reconnects").GetAttributeInt("value");
                }
            }

            set
            {
                lock (Document)
                {
                    Document.RootElement.SelectSingleElement("bot").SelectSingleElement("max_reconnects").SetAttribute("value", value);
                    Save();
                }
            }

        }

        public int Port
        {
            get
            {
                lock (Document)
                {
                    return  Document.RootElement.SelectSingleElement("bot").SelectSingleElement("port").GetAttributeInt("value");
                }
            }

            set
            {
                lock (Document)
                {
                    Document.RootElement.SelectSingleElement("bot").SelectSingleElement("port").SetAttribute("value", value);
                    Save();
                }
            }

        }

        /// <summary>
        /// Gets config parameter value from configurator (tag with attribute "value")
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetTag(string name)
        {
           return (Document.RootElement.SelectSingleElement("bot").HasTag(name)) ? Document.RootElement.SelectSingleElement("bot").SelectSingleElement(name).GetAttribute("value") : null;
        }

        /// <summary>
        /// Sets a specified configurator parameter (tag named "name") to "value"
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetTag(string name, string value)
        {
            bool exists = (Document.RootElement.SelectSingleElement("bot").HasTag(name));
            if (exists)
            {
                Document.RootElement.SelectSingleElement("bot").SelectSingleElement(name).SetAttribute("value", value);
                this.Save();
                return true;
            }
            return false;
        }



        public string Language
        {
            get
            {
                lock (Document)
                {
                    return Document.RootElement.SelectSingleElement("bot").SelectSingleElement("lang").GetAttribute("value");
                }
            }

            set
            {
                lock (Document)
                {
                    Document.RootElement.SelectSingleElement("bot").SelectSingleElement("lang").SetAttribute("value", value);
                    Save();
                }
            }

        }

    }
}
