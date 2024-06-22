namespace ContatosDeQuintoGrau.CoreBusiness 
{ 
    public class Contato
    {
        public Contato(string name, string email, string phone, string address)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Phone = phone;
            Address = address;            
        }
        public Contato()
        {
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
