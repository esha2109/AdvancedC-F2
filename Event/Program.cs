using System;

namespace Event
{
//	1)    Create a class to pass as an argument for the event handlers
//2)    Set up the delegate for the event
//3)    Declare the code for the event
//4)    Create code the will be run when the event occurs 
//5)    Associate the event with the event handler
	public class Program
	{
		public static void Main()
		{
			
			var person = new Person();
			person.name = "Syeda Esha";

			var alarm = new AlarmClock();
			alarm.AlarmClockEvent += person.HandleAlarm;
			alarm.Alarm();
		}
	}
	public class Person
	{
		public string name { get; set; }

		public void HandleAlarm(object sender, AlarmClockEventArgs e)
		{
			Console.WriteLine("Wake Up!", e.time);
		}

	}
	public class AlarmClock
	{
		public event AlarmClockEventHandeler AlarmClockEvent;

		public void Alarm()
		{
			Console.WriteLine("Turn Off the Alarm");
			AlarmClockEventHandeler alarm = AlarmClockEvent;
			if (AlarmClockEvent != null)
			{
				alarm(this, new AlarmClockEventArgs(DateTime.Now));
			}

		}
	}
	public delegate void AlarmClockEventHandeler(object source, AlarmClockEventArgs e);
	public class AlarmClockEventArgs : EventArgs
	{
		public DateTime time { get; set; }
		public AlarmClockEventArgs(DateTime time)
		{
			this.time = time;

		}
	}
}
