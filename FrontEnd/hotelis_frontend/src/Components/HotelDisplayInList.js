import { useEffect, useState } from "react";
import ImageService from "../Services/ImageService";

const HotelDisplayInList = ({ hotel, onClick }) => {
  const [imageUrl, setImageUrl] = useState("");
  useEffect(() => {
    ImageService.getByHotelID(hotel.hotelID, setImageUrl);
  }, []);

  return (
    <li className="HotelItem" onClick={onClick}>
      <div>
        <img src={imageUrl} alt="Loading" width="100%" height="200px" />
      </div>
      <p>{hotel.hotelName}</p>
      <p>
        {hotel.country} {hotel.city} {hotel.street} {hotel.number}
      </p>
    </li>
  );
};

export default HotelDisplayInList;
