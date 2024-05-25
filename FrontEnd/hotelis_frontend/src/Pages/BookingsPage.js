import { useNavigate } from "react-router-dom";
import { useState, useEffect } from "react";
import BookingService from "../Services/BookingService";
import HotelService from "../Services/HotelService";
import BookingDisplay from "../Components/BookingDisplay";
import HotelDisplayModal from "../Components/HotelDisplayModal";

const BookingsPage = () => {
  const [bookings, setBookings] = useState([]);
  const [hotel, setHotel] = useState(null);
  const [chosenId, setChosenId] = useState(null);

  let navigate = useNavigate();

  useEffect(() => {
    BookingService.getAll(setBookings);
  }, []);

  useEffect(() => {
    if (bookings.length > 0 && chosenBooking) {
      const id = chosenBooking.hotelID;
      HotelService.getbyId(id, setHotel);
    }
  }, [chosenId]);

  const handleDeleteBooking = (id) => {
    setBookings(bookings.filter((booking) => booking.id !== id));
  };

  const handleUpdateBooking = (updatedBooking) => {
    setBookings(
      bookings.map((prevBooking) => {
        return prevBooking.id !== updatedBooking.id
          ? prevBooking
          : updatedBooking;
      })
    );
    setChosenId(null);
  };

  const chosenBooking = chosenId
    ? bookings.find((x) => x.id === chosenId)
    : null;

  if (bookings.length === 0) {
    return (
      <div className="BookingsContainer">
        <h1 className="Bookings">No Bookings Yet</h1>
        <button
          onClick={() => {
            navigate("/");
          }}
          className="NavBtn"
        >
          Go Back
        </button>
      </div>
    );
  }
  return (
    <div>
      <div className="BookingsContainer">
        <h1 className="Bookings">Your Bookings</h1>
        <button
          onClick={() => {
            navigate("/");
          }}
          className="NavBtn"
        >
          Go Back
        </button>

        <ul className="BookingList">
          {bookings.map((booking) => {
            return (
              <BookingDisplay
                booking={booking}
                key={booking.id}
                onClick={() => setChosenId(booking.id)}
                onDelete={handleDeleteBooking}
              />
            );
          })}
        </ul>
        {chosenBooking && (
          <HotelDisplayModal
            open={chosenId !== null}
            onClose={() => {
              setHotel(null);
              setChosenId(null);
            }}
            hotel={hotel}
            from={chosenBooking.from}
            to={chosenBooking.to}
            booking={chosenBooking}
            updateBooking={handleUpdateBooking}
          />
        )}
      </div>
    </div>
  );
};

export default BookingsPage;
