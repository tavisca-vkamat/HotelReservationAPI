using System;
using CustomerOperation.Data;
using HotelOperation.Data;
using HotelReservation.Entity;
using RoomsOperation.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem
{
    class HotelReservationSystem
    {
        static void Main(string[] args)
        {
            int choice;
            CustomerDBImpl customerDBImpl = new CustomerDBImpl();
            HotelDBImpl hotelDBImpl = new HotelDBImpl();
            do
            {
                bool result = false;
                Console.Write("\n\n----Menu----\n1.Customer\n2.Agent\n3.Exit\nEnter choice: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\n1.Book room\n2.Check out from room\n3.Exit\n");
                        int choiceOfUser = int.Parse(Console.ReadLine());

                        /* book room customer */
                        if (choiceOfUser == 1)
                        {
                            /* search hotel by city name */
                            ArrayList arrOfHotels = null;
                            Console.Write("Enter city to search hotel: ");
                            string cityName = Console.ReadLine().ToLower();

                            arrOfHotels = HotelDBImpl.SearchHotelByCityName(cityName);

                            if (arrOfHotels.Count == 0)
                            {
                                Console.WriteLine("No rooms in this city.");
                                break;
                            }
                            Console.WriteLine("\nHotel ID " + " Hotel Name");
                            Console.WriteLine("-----------------------------");
                            foreach (Hotel hotel in arrOfHotels)
                            {
                                Console.WriteLine(hotel.hotelId + "\t   " + hotel.hotelName);
                            }

                            /*  search rooms in particular hotel */
                            Console.WriteLine("\nEnter hotel ID to book\n");
                            int hotelId = int.Parse(Console.ReadLine());

                            /* check if hotel Id given is in correct city */
                            int flagForHotelCheck = 0;
                            foreach (Hotel hotel in arrOfHotels)
                            {
                                if (hotel.city.CompareTo(cityName) == 0)
                                {
                                    if (hotel.hotelId == hotelId)
                                    {
                                        flagForHotelCheck = 1;
                                    }
                                }
                            }
                            if (flagForHotelCheck == 0)
                            {
                                Console.WriteLine("Invalid hotel Id !!");
                                break;
                            }
                            ArrayList arrOfRooms = null;

                            arrOfRooms = RoomsDbImpl.SelectRoomData(hotelId);

                            if (arrOfRooms.Count == 0)
                            {
                                Console.WriteLine("Invalid choice or No rooms available in this hotel");
                                break;
                            }
                            Console.WriteLine("Room Id :" + " Room Type " + " Available Rooms " + "  Price ");
                            Console.WriteLine("---------------------------------------------------------------");
                            foreach (RoomsData roomdata in arrOfRooms)
                            {
                                Console.WriteLine(roomdata.id + "\t " + roomdata.roomType + "\t " + roomdata.availableRooms + "\t\t " + roomdata.rentOfRoom);
                            }

                            /* book room */
                            Console.Write("\n\nEnter room Id to book room : ");
                            int roomId = int.Parse(Console.ReadLine());


                            Console.Write("\nAlready have customer ID:(y/n) : ");
                            string choiceForAddCustomer = Console.ReadLine();

                            /* if customer have customer id --> book room */
                            if (choiceForAddCustomer.ToLower() == "y")
                            {
                                Console.Write("Enter customer ID : ");
                                int customerId = int.Parse(Console.ReadLine());

                                result = RoomsDbImpl.BookRoom(roomId, customerId);
                                if (result)
                                {
                                    Console.WriteLine("\nRoom booked\n");
                                    Console.WriteLine("===========================================================");
                                }
                                else
                                    Console.WriteLine("\nRoom not available\n");
                            }
                            else if (choiceForAddCustomer.ToLower() == "n") /* create new customer if not present */
                            {
                                Console.Write("Enter customers's first name: ");
                                string customerFirstName = Console.ReadLine();

                                Console.Write("Enter customers's last name: ");
                                string customerLastName = Console.ReadLine();

                                Console.Write("Enter customers's email id: ");
                                string customerEmailId = Console.ReadLine();

                                Console.Write("Enter customers's phone number: ");
                                string customerPhoneNumber = Console.ReadLine();

                                int custID = customerDBImpl.InsertCustomer(customerFirstName, customerLastName, customerEmailId, customerPhoneNumber);

                                result = RoomsDbImpl.BookRoom(roomId, custID);
                                if (result)
                                    Console.WriteLine("\nRoom booked\n");
                                else
                                    Console.WriteLine("\nRoom not available\n");
                            }
                        }
                        else if (choiceOfUser == 2) // check out room form customer 
                        {
                            /* check out room */
                            Console.WriteLine("\nEnter booking ID");
                            int bookingId = int.Parse(Console.ReadLine());

                            result = RoomsDbImpl.CheckOutRoom(bookingId);
                            if (result)
                                Console.WriteLine("\nSuccessful checked out\n");
                            else
                                Console.WriteLine("\nSOme problem\n");
                        }
                        else if (choiceOfUser == 3)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice !\n");
                        }
                        break;

                    case 2:
                        /* agent menu starts */
                        Console.WriteLine("\n1.Create new hotel\n2.Create new room\n");
                        int choiceOfAgent = int.Parse(Console.ReadLine());

                        /* create new hotel entey */
                        if (choiceOfAgent == 1)
                        {
                            /* Enter Hotel data */
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

                            int hotelId = -1;
                            hotelId = hotelDBImpl.InsertHotel(hotelName, hotelEmailId, hotelPhoneNumber, city, hotelTotalrooms);
                            if (hotelId > 0)
                                Console.WriteLine("Hotel created with Id : " + hotelId);
                            else
                                Console.WriteLine("Error !!");
                        }
                        else if (choiceOfAgent == 2)/* create new room entey */
                        {
                            /* add rooms data */

                            Console.Write("Enter room details in hotel\n\nEnter hotel's ID: ");
                            int hotelId = int.Parse(Console.ReadLine());

                            Console.Write("Enter room type: ");
                            string roomType = Console.ReadLine();

                            Console.Write("Enter total rooms: ");
                            int totalRooms = int.Parse(Console.ReadLine());

                            Console.Write("Enter available rooms: ");
                            int availableRooms = int.Parse(Console.ReadLine());

                            Console.Write("Enter rent for room: ");
                            int rentForRoom = int.Parse(Console.ReadLine());

                            int roomId = RoomsDbImpl.InsertRoomData(hotelId, roomType, totalRooms, availableRooms,rentForRoom);
                            if (roomId > 0)
                                Console.WriteLine("Room created with ID: "+ roomId);
                            else
                                Console.WriteLine("Error !!");
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice !\n");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Thank you !!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice!!");
                        break;
                }
            }
            while (choice != 3);
        }
    }
}

