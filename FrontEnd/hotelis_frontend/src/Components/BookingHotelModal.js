import { useEffect, useState } from "react";
import InputLabel from "@mui/material/InputLabel";
import MenuItem from "@mui/material/MenuItem";
import FormControl from "@mui/material/FormControl";
import Select from "@mui/material/Select";
import HotelService from "../Services/HotelService";
import ImageService from "../Services/ImageService";
import BookingService from "../Services/BookingService";

const BookingHotelModel = ({
  hotel,
  from,
  to,
  setMsg,
  onClose,
  booking,
  updateBooking,
}) => {
  const [rooms, setRooms] = useState([]);
  const [room, setRoom] = useState(booking ? booking.room : 100);
  const [peopleCount, setPeopleCount] = useState(
    booking ? booking.peopleCount : 1
  );
  const [breakfast, setBreakfast] = useState(
    booking ? booking.breakfast : false
  );
  const [imageUrl, setImageUrl] = useState(null);
  const [price, setPrice] = useState(0);

  useEffect(() => {
    HotelService.getRooms(setRooms);
    ImageService.getByHotelID(hotel.hotelID, setImageUrl);
  }, []);

  const handleButton = () => {
    if (from.includes("Invalid") || to.includes("Invalid")) {
      setMsg("Choose date!");
      window.scrollTo({
        top: 0,
        behavior: "smooth",
      });
    } else if (!booking) {
      const hotelName = hotel.hotelName;
      const hotelID = hotel.hotelID;
      const bookingObj = {
        room,
        from,
        to,
        peopleCount,
        breakfast,
        price,
        hotelName,
        hotelID,
      };
      BookingService.create({ bookingObj });
    } else {
      booking = { ...booking, room, peopleCount, breakfast, price };
      BookingService.update({ booking }).then((data) => {
        updateBooking(data);
      });
    }
    onClose();
  };
  useEffect(() => {
    if (!from.includes("Invalid") && !to.includes("Invalid")) {
      BookingService.getPrice(
        room,
        peopleCount,
        breakfast,
        from,
        to,
        setPrice,
        setMsg,
        "Choose data!"
      );
    }
  }, [room, peopleCount, breakfast]);

  if (rooms.length !== 0) {
    return (
      <>
        <div className="HotelImage">
          <img src={imageUrl} alt="nekrauna" width="100%" height="600px" />
        </div>
        <div className="BookingInfo">
          <FormControl fullWidth>
            <InputLabel id="room-type-select-label">Room Type</InputLabel>
            <Select
              labelId="room-type-select-label"
              id="room-type-select"
              value={room}
              label="Room"
              onChange={(event) => setRoom(event.target.value)}
              defaultValue={100}
            >
              {rooms.map((room, index) => {
                return (
                  <MenuItem key={index} value={room.number}>
                    {room.name}
                  </MenuItem>
                );
              })}
            </Select>
          </FormControl>
          <FormControl fullWidth>
            <InputLabel id="people-count-select-label">People</InputLabel>
            <Select
              labelId="people-count-select-label"
              id="people-count-select"
              value={peopleCount}
              label="People"
              onChange={(event) => setPeopleCount(event.target.value)}
              defaultValue={1}
            >
              <MenuItem value={1}>One</MenuItem>
              <MenuItem value={2}>Two</MenuItem>
              <MenuItem value={3}>Three</MenuItem>
              <MenuItem value={4}>Four</MenuItem>
            </Select>
          </FormControl>
          <FormControl fullWidth>
            <InputLabel id="breakfast-select-label">
              Breakfast Option
            </InputLabel>
            <Select
              labelId="breakfast-select-label"
              id="breakfast-select"
              value={breakfast}
              label="Breakfast Option"
              onChange={(event) => setBreakfast(event.target.value)}
              defaultValue={false}
            >
              <MenuItem value={true}>Include</MenuItem>
              <MenuItem value={false}>Exclude</MenuItem>
            </Select>
          </FormControl>
          <p>
            20
            <span> &#8364;</span> will be added for cleaning fee
          </p>
          <p>
            PRICE: {price} <span> &#8364;</span>
          </p>
          <button className="bookingBtn" onClick={handleButton}>
            Book
          </button>
        </div>
      </>
    );
  }
};

export default BookingHotelModel;
