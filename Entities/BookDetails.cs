namespace Entities
{
    public class BookDetails
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }

        public BookDetails(int id, string FirstName, string LastName, string City,
            string Country, string Phone)
        {
            this.Id = id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.City = City;
            this.Country = Country;
            this.Phone = Phone;
        }
    }
}