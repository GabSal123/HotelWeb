import { useEffect, useState } from "react";
import InfoInput from "../Components/InfoInput";
import CustomDatePicker from "../Components/CustomDatePicker";
import HotelService from "../Services/HotelService";
import HotelList from "../Components/HotelList";
import NavBar from "../Components/NavBar";
import dayjs from "dayjs";
import Notification from "../Components/Notification";

const HotelsPage = () => {
  const [location, setLocation] = useState("");
  const [hotels, setHotels] = useState([]);
  const [from, setFrom] = useState(null);
  const [to, setTo] = useState(null);
  const [msg, setMsg] = useState(null);

  const showMessage = (message) => {
    setMsg(message);
    setTimeout(() => {
      setMsg(null);
    }, 7000);
  };

  useEffect(() => {
    if (location) {
      HotelService.getByCity(location, setHotels);
    } else {
      HotelService.getAll(setHotels);
    }
  }, [location]);

  const handleIncorrectDate = (newValue) => {
    setFrom(newValue);
    if (to && dayjs(newValue).isAfter(to, "days")) {
      setTo(null);
    }
  };

  return (
    <div className="MainContainer">
      <NavBar />
      <Notification message={msg} />
      <div className="SearchContainer">
        <InfoInput
          value={location}
          onChange={(event) => setLocation(event.target.value)}
          placeholder={"City"}
        />

        <CustomDatePicker
          text={"From"}
          value={from}
          func={handleIncorrectDate}
        />
        <CustomDatePicker
          text={"To"}
          value={to}
          func={setTo}
          minDate={dayjs(from).add(1, "day")}
        />
      </div>

      <div>
        <HotelList
          list={hotels}
          from={dayjs(from).format("YYYY-MM-DD")}
          to={dayjs(to).format("YYYY-MM-DD")}
          setMsg={showMessage}
        />
      </div>
    </div>
  );
};

export default HotelsPage;
