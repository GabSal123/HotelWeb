import { DatePicker } from "@mui/x-date-pickers/DatePicker";
import { LocalizationProvider } from "@mui/x-date-pickers/LocalizationProvider";
import { AdapterDayjs } from "@mui/x-date-pickers/AdapterDayjs";

const CustomDatePicker = ({ text, value, func, minDate }) => {
  return (
    <LocalizationProvider dateAdapter={AdapterDayjs}>
      <DatePicker
        label={text}
        value={value}
        onChange={(newValue) => func(newValue)}
        disablePast
        minDate={minDate}
      />
    </LocalizationProvider>
  );
};

export default CustomDatePicker;
