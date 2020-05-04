import React, { Component } from "react";
import liquorService from "../../services/liquor-service";
import HomeList from "../../components/Home/HomeList";
import Auxilary from "../../hoc/Auxilary";
import { Button } from "reactstrap";
import { Link } from "react-router-dom";

export class Home extends Component {
  static displayName = Home.name;
  constructor(props) {
    super(props);
    this.state = {
      liquors: [],
      totalCount: 1,
      pageSize: 5,
      pageNumber: 1,
      searchKeyword: "",
      sortColumn: "LiquorName",
      sortOrder: "Asc",
    };
  }

  async componentDidMount() {
    await this.handlePaginationChange(
      this.state.pageNumber,
      this.state.pageSize,
      this.state.sortColumn,
      this.state.sortOrder,
      this.state.searchKeyword
    );
  }
  handlePaginationChange = async (
    page,
    sizePerPage,
    sortField,
    sortOrder,
    searchKeyword,
    type
  ) => {
    var pageNum = type === "search" ? 1 : page;
    var result = await liquorService.getPaginatedData(
      sizePerPage,
      pageNum,
      searchKeyword,
      sortField,
      sortOrder
    );
    await this.setState({
      liquors: result.data,
      totalCount: result.paginationInfo.TotalCount,
      pageNumber: result.paginationInfo.CurrentPage,
      pageSize: result.paginationInfo.PageSize,
      sortColumn: sortField,
      sortOrder: sortOrder,
    });
  };

  handleTableChange = async (
    type,
    { searchText, page, sizePerPage, sortField, sortOrder }
  ) => {
    await this.handlePaginationChange(
      page,
      sizePerPage,
      sortField,
      sortOrder,
      searchText,
      type
    );
  };

  render() {
    return (
      <Auxilary>
        <Link to={"/add-liquor"}>
          <Button>Add</Button>
        </Link>
        <HomeList
          liquors={this.state.liquors}
          page={this.state.pageNumber}
          sizePerPage={this.state.pageSize}
          totalSize={this.state.totalCount}
          handleTableChange={this.handleTableChange}
        />
      </Auxilary>
    );
  }
}
