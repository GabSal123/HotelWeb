import { TextField } from "@mui/material";

const InfoInput = ({ value, onChange, placeholder }) => {
  return (
    <div>
      <TextField
        label={placeholder}
        variant="outlined"
        value={value}
        onChange={onChange}
      />
    </div>
  );
};

export default InfoInput;
