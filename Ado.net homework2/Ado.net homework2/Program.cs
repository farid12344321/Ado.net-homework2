using Ado.net_homework2.Data;
using Ado.net_homework2.Models;


SpeakersDao speakersDao = new SpeakersDao();
EventDao eventDao = new EventDao();


string opt;
do
{

    Console.WriteLine("1. Speakres\n");
    Console.WriteLine("2. Event\n");
  

    opt = Console.ReadLine();

    switch (opt)
    {
        case "1":
            Console.WriteLine("a : Insert Speakers:");
            Console.WriteLine("b : Update Speakers");
            Console.WriteLine("c : GetSpeakerById");
            Console.WriteLine("d : GetAllSpeaker");
            Console.WriteLine("e : DeleteSpeakers");
            string opt2 = Console.ReadLine();
            switch (opt2)
            {
                case "a":
                    Console.WriteLine("FullName :");
                    string fullname = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(fullname))
                    {
                        Console.WriteLine("Bos ola bilmez");
                        break;
                    }
                    Console.WriteLine("Position :");
                    string position = Console.ReadLine();

                    Console.WriteLine("Company :");
                    string company = Console.ReadLine();

                    Console.WriteLine("ImageUrl");
                    string image = Console.ReadLine();

                    Speakers speakers = new Speakers()
                    {
                        FullName = fullname,
                        Position = position,
                        Company = company,
                        Image = image
                    };

                    speakersDao.InsertSpeakers(speakers);
                    break;
                case "b":

                    Console.WriteLine("Id :");
                    string idstro = Console.ReadLine();
                    int id;
                    if (!int.TryParse(idstro,out id))
                    {
                        Console.WriteLine("Duzgun daxil edin");
                        break;
                    }

                    Console.WriteLine("FullName :");
                    fullname = Console.ReadLine();


                    Console.WriteLine("Position :");
                    position = Console.ReadLine();

                    Console.WriteLine("Company :");
                    company = Console.ReadLine();

                    Console.WriteLine("ImageUrl");
                    image = Console.ReadLine();
                    speakers = new Speakers()
                    {
                        Id = id,
                        FullName = fullname,
                        Position = position,
                        Company = company,
                        Image = image
                    };

                    speakersDao.UpdateSpeakers(speakers);
                    break;
                case "c":
                    Console.WriteLine("Id :");
                    string idopt2 = Console.ReadLine();
                    if (!int.TryParse(idopt2,out id))
                    {
                        Console.WriteLine("Duzgun id daxil edin");
                        break;
                    }

                    var data = speakersDao.GetSpeakersById(id);
                    if (data == null) Console.WriteLine("Speaker tapilmadi");
                    else Console.WriteLine(data);

                    break;
                case "d":
                    foreach (var item in speakersDao.GetAllSpeakers())
                    {
                        Console.WriteLine(item);
                    }
                    break;
                case "e":
                    Console.WriteLine("Id :");
                    string idopt3 = Console.ReadLine();
                    if (!int.TryParse(idopt3,out id))
                    {
                        Console.WriteLine("Duzgun id daxil edin");
                        break;
                    }
                    speakersDao.DeleteSpeakersById(id);
                    break;
                default:
                    Console.WriteLine("\nDuzgun opt secin\n");
                    break;
            }
            break;
        case "2":
            Console.WriteLine("a : Insert Events");
            Console.WriteLine("b : Get By id");
            Console.WriteLine("c : GettAll");
            Console.WriteLine("d : Add EventSpeaker");
            string opt3 = Console.ReadLine();
            switch (opt3)
            {
                case "a":
                    Console.WriteLine("Name :");
                    string nameOpt = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(nameOpt))
                    {
                        Console.WriteLine("Bosa ola bilmez");
                        break;
                    }

                    Console.WriteLine("Description :");
                    string descOpt = Console.ReadLine();

                    Console.WriteLine("Address :");
                    string addOpt = Console.ReadLine();

                    Console.WriteLine("StartDate :");
                    string startdateopt = Console.ReadLine();
                    DateTime startdate;

                    if (!DateTime.TryParse(startdateopt,out startdate))
                    {
                        Console.WriteLine("Duzgun date daxil edin");
                        break;
                    }
                    

                    Console.WriteLine("StartTime :");
                    string starttimeopt = Console.ReadLine();
                    DateTime starttime;
                    if (!DateTime.TryParse(starttimeopt,out starttime))
                    {
                        Console.WriteLine("Duzgun date daxil edin");
                        break;
                    }

                    Console.WriteLine("EndTime");
                    string endtimeOpt = Console.ReadLine();
                    DateTime endtime;
                    if (!DateTime.TryParse(endtimeOpt,out endtime))
                    {
                        Console.WriteLine("Duzgun date daxil edin");
                        break;
                    }

                    Events events = new Events()
                    {
                        Name = nameOpt,
                        Description = descOpt,
                        Address = addOpt,
                        StartDate = startdate,
                        StartTime = starttime,
                        EndTime = endtime
                    };
                    eventDao.InsertEvent(events);
                    break;
                case "b":
                    Console.WriteLine("Id :");
                    string idstr = Console.ReadLine();
                    int id;
                    if (!int.TryParse(idstr,out id))
                    {
                        Console.WriteLine("Duzgun daxil edin");
                        break;
                    }

                    var data = eventDao.GetEventsById(id);
                    if (data == null) Console.WriteLine("Evnt tapilmadi");
                    else Console.WriteLine(data);
                    break;
                case "c":
                    foreach (var item in eventDao.GetAllEvents())
                    {
                        Console.WriteLine(item);
                    }
                    break;
                case "d":
                    Console.WriteLine("Speaker Id:");
                    string speakeridOpt = Console.ReadLine();
                    int speakerid;
                    if (!int.TryParse(speakeridOpt,out speakerid))
                    {
                        Console.WriteLine("Duzgun Id daxil edin");
                        break;
                    }

                    Console.WriteLine("Event Id:");
                    string eventidopt = Console.ReadLine();
                    int eventid;
                    if (!int.TryParse(eventidopt,out eventid))
                    {
                        Console.WriteLine("Duzgun daxil edin");
                        break;
                    }

                    eventDao.AddSpeakerAndEvent(speakerid, eventid);
                    break;
                default:
                    Console.WriteLine("\nDuzgun opt secin\n");
                    break;
            }
           
            break;
        default:
            break;
    }
} while (opt != "0");