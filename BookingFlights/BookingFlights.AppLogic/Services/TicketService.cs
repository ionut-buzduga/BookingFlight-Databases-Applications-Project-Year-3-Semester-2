using BookingFlights.Abstractions.Repository;
using BookingFlights.Abstractions.Services;
using BookingFlights.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingFlights.AppLogic.Services
{
    public class TicketService: ITicketService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public TicketService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public IQueryable<Ticket> GetAllQueryable()
        {
            return _repositoryWrapper.TicketRepository.GetAll();
        }


        public void CreateFromEntity(Ticket ticket)
        {
            _repositoryWrapper.TicketRepository.Add(ticket);

        }

        public void ChooseTicket1(Ticket ticket)
        {
            _repositoryWrapper.TicketRepository.ChooseTicket1(ticket);
        }
        public void UpdateFromEntity(Ticket ticket)
        {
            _repositoryWrapper.TicketRepository.Update(ticket);
        }

        public void DeleteFromEntity(Ticket ticket)
        {
            _repositoryWrapper.TicketRepository.Delete(ticket);
        }

        public async System.Threading.Tasks.Task SaveAsync()
        {
            await _repositoryWrapper.TicketRepository.SaveAsync();


        }

        public void TicketForFLight(Ticket ticket)
        {
            _repositoryWrapper.TicketRepository.TicketForFlight(ticket);
        }

        public IQueryable<Ticket> findSpecificFlight(Guid id)
        {
            return _repositoryWrapper.TicketRepository.FindByCondition(ticket => ticket.FlightId == id);
        }
    }
}
