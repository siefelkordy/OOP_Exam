using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Exam
{
    public class Question
    {
        string header;
        string body;
        int mark;
        public string Header { get;
            set
            {
                if(value == null || value == " ")
                {
                    throw new NullReferenceException("Please enter a valid question header");
                }
                else
                {
                    header = value;
                }
            }
        }
        public string Body
        {
            get;
            set
            {
                if (value == null || value == " ")
                {
                    throw new NullReferenceException("Please enter a valid question header");
                }
                else
                {
                    body = value;
                }
            }
        }
        public int Mark
        { 
            get
            {
                return mark;
            }
            set
            {
                if(value < 0)
                {
                    throw new Exception("Enter a mark above 0");
                }
                else
                {
                    mark = value;
                }
            }
        }

    }
}
