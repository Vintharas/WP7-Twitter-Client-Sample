namespace TwitterClientPrototype.Model
{
    public class Tweet
    {
        public User User { get; set; }
        public string Text { get; set; }

    }

    public class User
    {
        public string Name { get; set; }
        public string Screen_Name
        {
            get { return "@" + screen_Name; } 
            set { screen_Name = value; }
        }
        private string screen_Name;
    }

}