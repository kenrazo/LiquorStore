import React, { Component } from "react";
import HomeList from "../../components/Home/HomeList";

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
      <div>
        <HomeList />
      </div>
    );
  }
}
