import { useEffect, useState } from "react";
import ImageService from "../Services/ImageService";
import dayjs from "dayjs";
import BookingService from "../Services/BookingService";

const BookingDisplay = ({ booking, onClick, onDelete }) => {
  const [imageUrl, setImageUrl] = useState(null);

  useEffect(() => {
    ImageService.getByHotelID(booking.hotelID, setImageUrl);
  }, []);

  const onClickDelete = () => {
    const id = booking.id;
    BookingService.deleteBooking({ id });
    onDelete(id);
  };

  if (!booking) {
    return null;
  }

  return (
    <li className="BookingItem">
      <div className="BookingImageContainer">
        <img src={imageUrl} alt="Loading" />
      </div>

      <p>{booking.hotelName}</p>
      <p>Arrival: {dayjs(booking.from).format("YYYY-MM-DD")}</p>
      <p>Exiting: {dayjs(booking.to).format("YYYY-MM-DD")}</p>
      <p>
        Price: {booking.price} <span> &#8364;</span>
      </p>
      <div className="BookingBtns">
        <button className="ControlBtn" onClick={onClickDelete}>
          Delete
        </button>
        <button className="ControlBtn" onClick={onClick}>
          Update
        </button>
      </div>
    </li>
  );
};

export default BookingDisplay;
