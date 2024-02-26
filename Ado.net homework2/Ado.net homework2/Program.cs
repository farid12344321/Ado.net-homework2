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
                    int id = Convert.ToInt32(Console.ReadLine());

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
                    id = Convert.ToInt32(Console.ReadLine());

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
                    id = Convert.ToInt32(Console.ReadLine());
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
            string opt3 = Console.ReadLine();
            switch (opt3)
            {
                case "a":
                    Console.WriteLine("Name :");
                    string nameOpt = Console.ReadLine();


                    Console.WriteLine("Description :");
                    string descOpt = Console.ReadLine();

                    Console.WriteLine("Address :");
                    string addOpt = Console.ReadLine();

                    Console.WriteLine("StartDate :");
                    DateTime startdate = Convert.ToDateTime(Console.ReadLine());

                    Console.WriteLine("StartTime :");
                    DateTime starttime = Convert.ToDateTime(Console.ReadLine());

                    Console.WriteLine("EndTime");
                    string endtimeOpt = Console.ReadLine();
                    DateTime endtime = Convert.ToDateTime(endtimeOpt);



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
                    int id = Convert.ToInt32(Console.ReadLine());

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
                default:
                    Console.WriteLine("\nDuzgun opt secin\n");
                    break;
            }
           
            break;
        default:
            break;
    }
} while (opt != "0");