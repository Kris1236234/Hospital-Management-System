namespace Hospital.Models
{
  public class Appointment
  {
    public int Id { get; set; }
    public string Number { get; set; }
    public string Name { get; set; }
    public string DoctorStatus { get; set; }
    public string Type { get; set; }
    public DateTime AppointmentTime { get; set; }
    public DateTime AppointmentEndTime { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Description { get; set; }
    public Doctor Doctor { get; set; }
    public Patient Patient { get; set; }
    public int DoctorId { get; set; }
    public int PatientId { get; set; }
    public int RoomId { get; set; }
    public Room Room { get; set; }
  }
}