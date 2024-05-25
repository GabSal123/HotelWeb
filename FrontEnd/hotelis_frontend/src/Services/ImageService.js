import axios from "axios";
import { IMAGE_URL } from "./config.js";

const getByHotelID = (id, setImageUrl) => {
  const url = `${IMAGE_URL}GetImage?hotelID=${id}`;

  const request = axios.get(url, {
    responseType: "blob",
  });

  request.then((res) => {
    const obj = URL.createObjectURL(res.data);
    setImageUrl(obj);
  });
};

export default { getByHotelID };
