import React, { Component } from "react";
import { Breadcrumb, BreadcrumbItem } from "reactstrap";
import liquorService from "../../services/client-service";
import ToolkitProvider, { Search } from "react-bootstrap-table2-toolkit";
import BootstrapTable from "react-bootstrap-table-next";
import paginationFactory from "react-bootstrap-table2-paginator";

const { SearchBar } = Search;
const RemoteTable = ({
  columns,
  keyField,
  data,
  page,
  sizePerPage,
  onTableChange,
  totalSize,
}) => (
  <div>
    <ToolkitProvider keyField={keyField} data={data} columns={columns} search>
      {(props) => (
        <div>
          <SearchBar {...props.searchProps} />
          <BootstrapTable
            {...props.baseProps}
            remote
            onTableChange={onTableChange}
            pagination={paginationFactory({ page, sizePerPage, totalSize })}
            striped
            hover
            condensed
            noDataIndication="No records found"
          />
        </div>
      )}
    </ToolkitProvider>
  </div>
);

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
      sortColumn: "ClientName",
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
    const columns = [
      {
        dataField: "liquorId",
        text: "Liquor ID",
        sort: true,
      },
      {
        dataField: "liquorName",
        text: "Liquor Name",
        sort: true,
      },
      {
        dataField: "liquorType",
        text: "Liquor Type",
        sort: true,
      },
    ];
    return (
      <div>
        <Breadcrumb tag="nav" listTag="div">
          <BreadcrumbItem active tag="span">
            Liquors
          </BreadcrumbItem>
        </Breadcrumb>
        <h1>Liquors</h1>
        <br />
        <RemoteTable
          columns={columns}
          keyField="liquorId"
          data={this.state.liquors}
          page={this.state.pageNumber}
          sizePerPage={this.state.pageSize}
          totalSize={this.state.totalCount}
          onTableChange={this.handleTableChange}
        />
      </div>
    );
  }
}
