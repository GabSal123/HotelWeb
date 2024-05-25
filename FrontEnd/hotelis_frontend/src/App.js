import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import HotelsPage from "./Pages/HotelsPage";
import BookingsPage from "./Pages/BookingsPage";
import "./Styles/styles.css";

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/Bookings" element={<BookingsPage />} />
        <Route path="/" element={<HotelsPage />} />
      </Routes>
    </Router>
  );
}

export default App;
