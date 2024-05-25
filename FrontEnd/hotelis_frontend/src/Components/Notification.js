const Notification = ({ message }) => {
  if (!message) return null;

  return (
    <div className="Notification">
      <h5>{message}</h5>
    </div>
  );
};

export default Notification;
