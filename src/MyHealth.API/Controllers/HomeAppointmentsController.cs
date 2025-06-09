using Microsoft.AspNetCore.Mvc;
using SmartClinic.Data.Repositories;
using SmartClinic.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using SmartClinic.API.AppExtensions;

namespace SmartClinic.API.Controllers
{
    [ResponseCache(Duration = 0, NoStore = true, VaryByHeader = "*")]
    [Route("api/[controller]")]
    public class HomeAppointmentsController : Controller
    {
        private readonly HomeAppointmentRepository _VisitsRepository = null;

        public HomeAppointmentsController(HomeAppointmentRepository visitsRepository)
        {
            _VisitsRepository = visitsRepository;
        }

        [HttpGet("{id}")]
        public async Task<HomeAppointment> Get(int id)
        {
            return await _VisitsRepository.GetAsync(Request.GetTenant(), id);
        }

        [HttpGet("NextVisits/{patientId}")]
        public async Task<IEnumerable<HomeAppointment>> GetNextVisits(int patientId, int count)
        {
            return await _VisitsRepository.GetNextVisitsAsync(Request.GetTenant(), patientId, count);
        }

        [HttpGet("Visited/{patientId}")]
        public async Task<IEnumerable<HomeAppointment>> GetVisitedAsync(int patientId, int count)
        {
            return await _VisitsRepository.GetVisitedAsync(Request.GetTenant(), patientId, count);
        }

        [HttpPut()]
        public async Task UpdateAsync([FromBody]HomeAppointment appointment)
        {
            await _VisitsRepository.UpdateAsync(appointment);
        }
    }
}
