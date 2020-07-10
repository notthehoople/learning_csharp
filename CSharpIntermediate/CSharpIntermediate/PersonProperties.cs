using System;

namespace CSharpIntermediate
{
    public class PersonProperties
    {
        // Fields / Properties

        // We declare the "set" property to be private to stop the birthdate being changed later
        //      This means that the birthdate needs to be set in the constructor
        public DateTime Birthdate { get; private set; }
        public string Name { get; set; }

        public int Age
        {
            // Can't use auto-implemented properties here as we need to calculate the age in years
            // Set: we don't need one of these, as it doesn't make sense
            get
            {
                var timeSpan = DateTime.Today - Birthdate;
                var years = timeSpan.Days / 365;

                return years;
            }
        }


        // Methods
        // Constructor
        public PersonProperties(DateTime birthdate)
        {
            Birthdate = birthdate;
        }
    }
}
