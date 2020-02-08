import React, { Component } from 'react';
import { Link } from 'react-router-dom';

interface ILocalState {
  collapsed: boolean
}

export class NavMenu extends Component<{}, ILocalState> {
  static displayName = NavMenu.name;

  constructor (props: any) {
    super(props);

    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
      collapsed: true
    };
  }

  toggleNavbar () {
    this.setState({
      collapsed: !this.state.collapsed
    });
  }

  render () {
    return (
      <div className="bg-indigo-700 flex justify-center">
        <nav className="full-page flex justify-between flex-wrap">
          <div className="flex items-center flex-shrink-0 text-white mr-6">
            <Link to="/" className="font-semibold text-xl tracking-tight">pineapple</Link>
          </div>
          <div className="block lg:hidden">
            <button className="flex items-center px-3 py-2 border rounded text-indigo-200 border-indigo-400 hover:text-white hover:border-white" onClick={this.toggleNavbar}>
              <svg className="fill-current h-3 w-3" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg"><title>Menu</title><path d="M0 3h20v2H0V3zm0 6h20v2H0V9zm0 6h20v2H0v-2z"/></svg>
            </button>
          </div>
          <div className={`w-full block flex-grow lg:flex lg:items-center lg:w-auto ${this.state.collapsed ? 'hidden' : ''}`}>
            <div className="text-sm lg:flex-grow">
              <Link to="/" className="block mt-4 lg:inline-block lg:mt-0 text-indigo-100 hover:text-white mr-4">Home</Link>
              <a href="/$/swagger/" className="block mt-4 lg:inline-block lg:mt-0 text-indigo-100 hover:text-white">API</a>
            </div>
          </div>
        </nav>
      </div>
    );
  }
}
