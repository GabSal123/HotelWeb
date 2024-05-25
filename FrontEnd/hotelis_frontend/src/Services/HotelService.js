import { HOTEL_URL } from "./config.js";
import fetchData from "./fetchData.js";

const getAll = (setData) => {
  const url = `${HOTEL_URL}GetAll`;
  fetchData(url, setData);
};

const getRooms = (setData) => {
  const url = `${HOTEL_URL}GetRooms`;
  fetchData(url, setData);
};

const getbyId = (id, setData) => {
  const url = `${HOTEL_URL}GetById?id=${id}`;
  fetchData(url, setData);
};

const getByCity = (city, setData) => {
  const url = `${HOTEL_URL}GetByCity?city=${city}`;
  fetchData(url, setData);
};

export default {
  getAll,
  getRooms,
  getbyId,
  getByCity,
};
