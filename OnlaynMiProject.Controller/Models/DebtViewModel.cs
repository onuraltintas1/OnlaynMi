using OnlaynMiProject.EntityLayer;
using OnlaynMiProject.EntityLayer.Concrete;

namespace OnlaynMiProject.Controller.Models;

public class DebtViewModel
{
    public List<Transfer> TransferResultViewModel { get; set; }
    public List<AppUser> AppUser { get; set; }
}