using System;

namespace Client
{
    public enum UserEvent
    {
        NewChild
    };


    public class UserEventArgs : EventArgs
    {
        public  UserEvent UserEvent { get; set; }
        public  Object Data { get; set; }

        public UserEventArgs(UserEvent userEvent, object data)
        {
            UserEvent = userEvent;
            Data = data;
        }
    }
}