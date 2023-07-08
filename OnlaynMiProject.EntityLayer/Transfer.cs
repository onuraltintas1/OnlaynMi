using OnlaynMiProject.EntityLayer.Concrete;

namespace OnlaynMiProject.EntityLayer;

public class Transfer
{

        public int TransferId { get; set; }
      
        public decimal Pay { get; set; }
        public int FromId { get; set; }
        public AppUser From { get; set; }
    
        public int ToId { get; set; }
        public AppUser To { get; set; }
        
        public int EventId { get; set; }
        public Event Event  { get; set; }
        
        

    
}