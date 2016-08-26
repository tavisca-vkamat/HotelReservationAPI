using CustomerOperation.Data;
using HotelOperation.Data;
using HotelReservation.Entity;
using RoomsOperation.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem
{
    class HotelReservation
    {
        static void Main(string[] args)
        {
            int choice;
            CustomerDBImpl customerDBImpl = new CustomerDBImpl();
            HotelDBImpl hotelDBImpl = new HotelDBImpl();
            do
            {
                Console.Write("\n\n-------------MENU-------------\n1.Add customer\n2.Add hotel\n3.Add rooms to hotel\n4.Search hotel\n5.Book room\n6.Check out room\n7.Exit\n");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        /*add customer */
                        Console.Write("Enter customers's first name: ");
                        string customerFirstName = Console.ReadLine();

                        Console.Write("Enter customers's last name: ");
                        string customerLastName = Console.ReadLine();

                        Console.Write("Enter customers's email id: ");
                        string customerEmailId = Console.ReadLine();

                        Console.Write("Enter customers's phone number: ");
                        string customerPhoneNumber = Console.ReadLine();
                        bool result = customerDBImpl.InsertCustomer(customerFirstName, customerLastName, customerEmailId, customerPhoneNumber);
                        if (result)
                            Console.WriteLine("Insertion successful");
                        else
                            Console.WriteLine("Error !!");
                        break;
                    case 2:
                        /* add hotel */
                        Console.Write("Enter hotel's name: ");
                        string hotelName = Console.ReadLine();

                        Console.Write("Enter hotel's email ID: ");
                        string hotelEmailId = Console.ReadLine();

                        Console.Write("Enter hotel's phone number: ");
                        string hotelPhoneNumber = Console.ReadLine();

                        Console.Write("Enter hotel's city: ");
                        string city = Console.ReadLine();

                        Console.Write("Enter hotel's total number of rooms in hotel: ");
                        string hotelTotalrooms = Console.ReadLine();

                        result = hotelDBImpl.InsertHotel(hotelName, hotelEmailId, hotelPhoneNumber, city, hotelTotalrooms);
                        if (result)
                            Console.WriteLine("Insertion successful");
                        else
                            Console.WriteLine("Error !!");
                        break;
                    case 3:
                        /* add rooms data */
                        Console.Write("Enter hotel's ID: ");
                        int hotelId = int.Parse(Console.ReadLine());

                        Console.Write("Enter room type: ");
                        string roomType = Console.ReadLine();

                        Console.Write("Enter total rooms: ");
                        int totalRooms = int.Parse(Console.ReadLine());

                        Console.Write("Enter available rooms: ");
                        int availableRooms = int.Parse(Console.ReadLine());

                        result = RoomsDbImpl.InsertRoomData(hotelId, roomType, totalRooms, availableRooms);
                        if (result)
                            Console.WriteLine("Insertion successful");
                        else
                            Console.WriteLine("Error !!");
                        break;
                    case 4:
                        /* select rooms */
                        ArrayList arrOfRooms = null;
                        Console.WriteLine("1.AC \n2.Non-AC");
                        int choiceOfRoom = int.Parse(Console.ReadLine());
                        if (choiceOfRoom == 1)
                        {
                            arrOfRooms = RoomsDbImpl.SelectRoomData("AC");
                        }
                        else if (choiceOfRoom == 2)
                        {
                            arrOfRooms = RoomsDbImpl.SelectRoomData("NON-AC");
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice");
                        }
                        if (arrOfRooms == null)
                        {
                            break;
                        }
                        Console.WriteLine("Room Id :" + "Hotel ID: " + " Room Type " + " Available Rooms " + "  Total Rooms ");
                        foreach (RoomsData roomdata in arrOfRooms)
                        {
                            Console.WriteLine(roomdata.id + "\t" + roomdata.hotelId + "\t    " + roomdata.roomType + "\t  " + roomdata.availableRooms + "\t\t " + roomdata.totalRooms);
                        }
                        break;
                    case 5:
                        /* book room */
                        Console.WriteLine("\nEnter room ID");
                        int roomID = int.Parse(Console.ReadLine());

                        Console.WriteLine("\nEnter customer ID");
                        int customerId = int.Parse(Console.ReadLine());

                        result = RoomsDbImpl.BookRoom(roomID, customerId);
                        if (result)
                            Console.WriteLine("\nRoom booked\n");
                        else
                            Console.WriteLine("\nRoom not available\n");

                        break;
                    case 6:
                        /* check out room */
                        Console.WriteLine("\nEnter booking ID");
                        int bookingId = int.Parse(Console.ReadLine());

                        result = RoomsDbImpl.CheckOutRoom(bookingId);
                        if (result)
                            Console.WriteLine("\nSuccessful checked out\n");
                        else
                            Console.WriteLine("\nSOme problem\n");

                        break;
                    case 7:
                        Console.WriteLine("Thank you !!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice!!");
                        break;

                }
            }
            while (choice != 7);
        }
    }
}
