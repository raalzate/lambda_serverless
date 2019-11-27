namespace microservice.Models {

    public class Item
    {
        public Item(){}

        public Item(int Id, string Name){
          this.Name = Name;
          this.Id = Id;
        }
        
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
