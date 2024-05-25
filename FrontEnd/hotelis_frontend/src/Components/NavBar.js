import { useNavigate } from "react-router-dom";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faHotel } from "@fortawesome/free-solid-svg-icons";

const NavBar = () => {
  let navigate = useNavigate();
  return (
    <div className="NavBar">
      <FontAwesomeIcon icon={faHotel} className="Icon" />
      <h1>Hotel Web</h1>
      <button
        onClick={() => {
          navigate("/Bookings");
        }}
        className="bookingBtn"
      >
        Booking Page
      </button>
    </div>
  );
};

export default NavBar;
