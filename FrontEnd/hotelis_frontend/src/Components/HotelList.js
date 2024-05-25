import { useState } from "react";
import HotelDisplayInList from "./HotelDisplayInList";
import HotelDisplayModal from "./HotelDisplayModal";

const HotelList = ({ list, from, to, setMsg }) => {
  const [chosenHotelID, setChosenHotelID] = useState(null);

  const chosenHotel =
    chosenHotelID !== null
      ? list.find((x) => x.hotelID == chosenHotelID)
      : null;

  return (
    <>
      <ul className="ListContainer">
        {list.map((item) => {
          return (
            <HotelDisplayInList
              hotel={item}
              key={item.hotelID}
              onClick={() => setChosenHotelID(item.hotelID)}
            />
          );
        })}
      </ul>
      <HotelDisplayModal
        open={chosenHotelID !== null}
        onClose={() => setChosenHotelID(null)}
        hotel={chosenHotel}
        from={from}
        to={to}
        setMsg={setMsg}
      />
    </>
  );
};

export default HotelList;
