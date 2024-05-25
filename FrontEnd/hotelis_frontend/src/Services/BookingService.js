import axios from "axios";
import { BOOKING_URL } from "./config.js";
import fetchData from "./fetchData.js";

const getPrice = (
  room,
  peopleCount,
  breakfast,
  from,
  to,
  setData,
  setError,
  message
) => {
  const url = `${BOOKING_URL}GetPrice?roomCost=${room}&peopleCount=${peopleCount}&breakfastOption=${breakfast}&from=${from}&to=${to}`;
  fetchData(url, setData, setError, message);
};

const create = ({ bookingObj }) => {
  const url = `${BOOKING_URL}Create`;
  const request = axios.post(url, bookingObj);
  return request.then((res) => res.data);
};

const getAll = (setData) => {
  const url = `${BOOKING_URL}GetAll`;
  fetchData(url, setData);
};

const deleteBooking = ({ id }) => {
  const url = `${BOOKING_URL}Delete?id=${id}`;
  const request = axios.delete(url);
  return request.then((res) => res.data);
};

const update = ({ booking }) => {
  const url = `${BOOKING_URL}Update`;
  const request = axios.put(url, booking);
  return request.then((res) => res.data);
};

export default { getPrice, create, getAll, deleteBooking, update };
