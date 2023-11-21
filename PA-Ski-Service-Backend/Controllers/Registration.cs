using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using SkiServiceBackend.Models;
using System;
using System.Linq;
using SkiServiceBackend.Dtos;


[ApiController]
[Route("api/[controller]")]
public class SkiServiceRegistrationController : ControllerBase
{
    private readonly ApplicationContext _dbContext;

    public SkiServiceRegistrationController(ApplicationContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Alle Registrierungen abrufen
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult Get()
    {
        var registrations = _dbContext.RegisteredUsers.ToList();
        return Ok(registrations);
    }

    /// <summary>
    /// Registrierung nach Name abrufen
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    [HttpGet("{name}")]
    public IActionResult Get(string name)
    {
        var registration = _dbContext.RegisteredUsers.FirstOrDefault(r => r.FullName == name);

        if (registration == null)
        {
            return NotFound("Registration not found");
        }

        return Ok(registration);
    }

    /// <summary>
    /// Neue Registrierung hinzufügen
    /// </summary>
    /// <param name="registrationDto"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult Post([FromBody] SkiServiceRegistrationDto registrationDto)
    {
        if (registrationDto == null)
        {
            return BadRequest("Invalid data");
        }

        try
        {
            var registrationModel = new RegisteredCustomer
            {
                FullName = registrationDto.Name,
                EmailAddress = registrationDto.Email,
                PhoneNumber = registrationDto.Phone,
                Priority = registrationDto.Priority,
                Service = registrationDto.Service,
                CreatedAt = registrationDto.CreatedAt,
                PickupDate = registrationDto.PickupDate
            };

            // Daten zur Datenbank hinzufügen und Änderungen speichern
            registrationModel.CreatedAt = DateTime.Now;
            _dbContext.RegisteredUsers.Add(registrationModel);
            _dbContext.SaveChanges();

            return Ok("Data received successfully and saved to the database");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }

    /// <summary>
    /// Registrierung aktualisieren
    /// </summary>
    /// <param name="name"></param>
    /// <param name="registrationDto"></param>
    /// <returns></returns>
    [HttpPut("{name}")]
    public IActionResult Put(string name, [FromBody] SkiServiceRegistrationDto registrationDto)
    {
        var existingRegistration = _dbContext.RegisteredUsers.FirstOrDefault(r => r.FullName == name);

        if (existingRegistration == null)
        {
            return NotFound("Registration not found");
        }

        // Eigenschaften der vorhandenen Registrierung mit neuen Daten aktualisieren
        existingRegistration.FullName = registrationDto.Name;
        existingRegistration.EmailAddress = registrationDto.Email;
        existingRegistration.PhoneNumber = registrationDto.Phone;
        existingRegistration.Priority = registrationDto.Priority;
        existingRegistration.Service = registrationDto.Service;
        existingRegistration.PickupDate = registrationDto.PickupDate;

        // Änderungen in der Datenbank speichern
        _dbContext.SaveChanges();

        return Ok("Registration updated successfully");
    }

    /// <summary>
    /// Registrierung löschen
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    [HttpDelete("{name}")]
    [Authorize]
    public IActionResult Delete(string name)
    {
        var registration = _dbContext.RegisteredUsers.FirstOrDefault(r => r.FullName == name);

        if (registration == null)
        {
            return NotFound("Registration not found");
        }

        // Registrierung aus der Datenbank entfernen
        _dbContext.RegisteredUsers.Remove(registration);
        _dbContext.SaveChanges();

        return Ok("Registration deleted successfully");
    }
}

internal class RegisteredCustomer : RegisteredUser
{
    public string FullName { get; set; }
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }
    public string Priority { get; set; }
    public string Service { get; set; }
    public object CreatedAt { get; set; }
    public DateTime PickupDate { get; set; }
}