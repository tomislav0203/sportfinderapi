using Model.DomainModels;
using SportFinderApi.DTO;
using SportFinderApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SportFinderApi.Controllers
{
    public class EventsController : ApiController
    {
        private IEventRepository _eventRepo;
        private IUserRepository _userRepo;

        public EventsController(IEventRepository eventRepo, IUserRepository userRepo)
        {
            _eventRepo = eventRepo;
            _userRepo = userRepo;
        }

        [HttpPost]
        //GET api/events/create
        public IHttpActionResult Create(EventDto eventDto)
        {
            string validationMessage = eventDto.validateForCreation();
            if (!String.IsNullOrEmpty(validationMessage)) return BadRequest(validationMessage);
            User user = _userRepo.Single(x => x.UserName.Equals(eventDto.UserName));
            if(user == null) return BadRequest("navedeni korisnik ne postoji");
            City city = _userRepo.FindCity(eventDto.CityName);
            if(city == null) return BadRequest("navedeni grad ne postoji");
            Event ev = EventMapper.MapEventDtoToEvent(eventDto);
            ev.Creator = user;
            ev.City = city;
            ev.Creator = user;
            ev.Sport = new Sport() { Id = eventDto.SportId };

            _eventRepo.Add(ev);
            return Ok();

        }

        [HttpGet]
        //GET api/events/getbycity
        public IHttpActionResult GetByCity(string username, string date)
        {
            if (username == null) return BadRequest("username nije zadan");
            if (date == null) return BadRequest("datum nije zadan");
            User user = _userRepo.Single(x => x.UserName.Equals(username));
            DateTime userDateTime = DateTime.ParseExact(date, "dd/MM/yyyy", null);
            List<EventDto> events = EventMapper.MapEventsToEventDto(_eventRepo.All(x => x.City.Id == user.City.Id && x.StartTime.Date.Equals(userDateTime.Date)));
            return Ok(events);

        }

        [HttpGet]
        //GET api/events/getuserevents
        public IHttpActionResult GetUserEvents(string username)
        {
            if (username == null) return BadRequest("username nije zadan");
            User user = _userRepo.Single(x => x.UserName.Equals(username));
            List<Event> events = _eventRepo.All(x => x.Participants.Where(p => p.UserName.Equals(username)).Any() || x.Creator.UserName.Equals(username)).ToList();
            UserEventsDto userEvents = new UserEventsDto();
            userEvents.PastEvents = EventMapper.MapEventsToEventDto(events.Take(10).Where(x => x.StartTime.CompareTo(DateTime.Now) < 0));
            userEvents.FutureEvents = EventMapper.MapEventsToEventDto(events.Take(10).Where(x => x.StartTime.CompareTo(DateTime.Now) > 0));
            return Ok(userEvents);

        }

        [HttpGet]
        //GET api/events/findevents
        public IHttpActionResult FindEvents(int sportId, DateTime? date, string cityName, int freePlayers)
        {
            List<EventDto> events = new List<EventDto>();

            if (date == null)
            {
                events = EventMapper.MapEventsToEventDto(_eventRepo.All(x => x.FreePlayers >= freePlayers && x.Sport.Id == sportId).ToList());
            }
            else
            {
                events = EventMapper.MapEventsToEventDto(_eventRepo.All(x => x.StartTime.Date == date.Value.Date && x.FreePlayers >= freePlayers && x.Sport.Id == sportId).ToList());
            }
            City city = _userRepo.FindCity(cityName);
            if (city == null) return BadRequest("navedeni grad ne postoji");
            return Ok(events);
        }

        [HttpGet]
        //GET api/events/getevent
        public IHttpActionResult GetEvent(int id)
        {
            Event ev = _eventRepo.Single(x => x.Id == id);
            if (ev == null) return BadRequest("event ne postoji");
            List<UserDto> participants = UsersMapper.MapUserToUserDto(ev.Participants.ToList(), ev.Sport.Id);
            participants.Add(UsersMapper.MapUserToUserDto(ev.Creator));
            EventParticipantsDto result = EventMapper.MapEventsToEventParticipantsDto(ev, participants);
            return Ok(result);
        }


        [HttpGet]
        //GET api/events/getallsports
        public IHttpActionResult GetAllSports()
        {
            return Ok(_eventRepo.GetAllSports());
        }
    }
}
