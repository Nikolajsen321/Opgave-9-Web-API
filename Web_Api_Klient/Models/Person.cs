namespace Opgave_9_Rest_webapplikationer
{
    public class Person
    {
        private string name;
        public string Name { get { return name; } } 
        private int age;
        public int Age { get { return age; } }

        private int id;
        public int Id { get { return id; } }    

        public Person( int id, string name, int age)
        {
            this.name = name;
            this.age = age;
            this.id = id;
        }   



    }
}
