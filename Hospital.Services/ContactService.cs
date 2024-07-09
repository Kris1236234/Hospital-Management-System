using Hospital.Models;
using Hospital.Repositories.Interfaces;
using Hospital.Services;
using Hospital.ViewModels;
using hospitals.Utilities;

public class ContactService : IContactService
{
    private readonly IUnitOfWork _unitOfWork;

    public ContactService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public PagedResult<ContactViewModel> GetAll(int pageNumber, int pageSize)
    {
        int excludeRecords = (pageSize * pageNumber) - pageSize;

        var contactQuery = _unitOfWork.GenericRepository<Contact>().GetAll();

        int totalCount = contactQuery.Count();

        var contactList = contactQuery.Skip(excludeRecords)
                                      .Take(pageSize)
                                      .ToList();

        var contactViewModelList = ConvertModelToViewModelList(contactList);

        var result = new PagedResult<ContactViewModel>
        {
            Data = contactViewModelList,
            TotalItems = totalCount,
            PageNumber = pageNumber,
            PageSize = pageSize
        };

        return result;
    }

    public void CreateContact(ContactViewModel viewModel)
    {
        var contact = viewModel.ConvertViewModelToModel();
        _unitOfWork.GenericRepository<Contact>().Add(contact);
        _unitOfWork.Save();
    }

    public void UpdateContact(ContactViewModel viewModel)
    {
        var contact = _unitOfWork.GenericRepository<Contact>().GetById(viewModel.Id);
        if (contact == null) return;

        contact.Phone = viewModel.Phone;
        contact.Email = viewModel.Email;
    

        _unitOfWork.GenericRepository<Contact>().Update(contact);
        _unitOfWork.Save();
    }

    public void DeleteContact(int contactId)
    {
        var contact = _unitOfWork.GenericRepository<Contact>().GetById(contactId);
        if (contact == null) return;

        _unitOfWork.GenericRepository<Contact>().Delete(contact);
        _unitOfWork.Save();
    }

    private List<ContactViewModel> ConvertModelToViewModelList(List<Contact> contactList)
    {
        return contactList.Select(c => new ContactViewModel(c)).ToList();
    }

    public ContactViewModel GetContactById(int contactId)
    {
        var contact = _unitOfWork.GenericRepository<Contact>().GetById(contactId);
        return contact != null ? new ContactViewModel(contact) : null;
    }

    public void InsertContact(ContactViewModel contact)
    {
        var model = contact.ConvertViewModelToModel();
        _unitOfWork.GenericRepository<Contact>().Add(model);
        _unitOfWork.Save();
    }

    public IEnumerable<ContactViewModel> GetContactsByHospital(int hospitalId)
    {
     
        var contacts = _unitOfWork
            .GenericRepository<Contact>()
            .GetAll()
            .Where(c => c.HospitalId == hospitalId)
            .ToList();


        return contacts.Select(c => new ContactViewModel(c));
    }

    public IEnumerable<ContactViewModel> SearchContacts(string searchTerm)
    {
      
        var contacts = _unitOfWork
            .GenericRepository<Contact>()
            .GetAll()
            .Where(c => c.Email.Contains(searchTerm) || c.Phone.Contains(searchTerm))
            .ToList();

      
        return contacts.Select(c => new ContactViewModel(c));
    }

}
