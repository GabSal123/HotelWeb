import axios from "axios";

const fetchData = (url, setData, setError, message) => {
  const request = axios.get(url);
  request
    .then((res) => res.data)
    .then((data) => setData(data))
    .catch(() => {
      if (setError) {
        setError(message);
      }
    });
};

export default fetchData;
