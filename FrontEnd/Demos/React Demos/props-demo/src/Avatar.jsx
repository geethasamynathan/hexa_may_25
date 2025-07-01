import React from "react";
import { useUser } from "./UserContext";

export default function Avatar() {
  const user = useUser();
  return (
    <>
      <img
        src={user.avatarUrl}
        alt={user.name}
        style={{ borderRadius: "50%" }}
      ></img>
    </>
  );
}
