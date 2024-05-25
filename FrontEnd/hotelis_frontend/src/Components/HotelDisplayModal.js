import React from "react";
import Modal from "@mui/material/Modal";
import BookingHotelModel from "./BookingHotelModal";

const HotelDisplayModal = ({
  open,
  onClose,
  hotel,
  from,
  to,
  setMsg,
  booking,
  updateBooking,
}) => {
  if (!hotel) return null;

  return (
    <Modal
      className="modalContainer"
      open={open}
      onClose={onClose}
      aria-labelledby="parent-modal-title"
      aria-describedby="parent-modal-description"
    >
      <div className="modalInfo">
        <h2>{hotel.hotelName}</h2>
        <div className="bookingModalContainer">
          <BookingHotelModel
            hotel={hotel}
            from={from}
            to={to}
            onClose={onClose}
            setMsg={setMsg}
            booking={booking}
            updateBooking={updateBooking}
          />
        </div>
      </div>
    </Modal>
  );
};

export default HotelDisplayModal;
