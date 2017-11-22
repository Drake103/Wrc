import * as React from "react";
import { Route } from "react-router-dom";
import { Layout } from "./components/Layout";
import ReplaysApp from "./components/replays/ReplaysApp";
import FetchData from "./components/FetchData";
import Counter from "./components/Counter";
import UploadReplay from "./components/replays/UploadReplay";

export const routes = (
    <Layout>
        <Route exact path="/replays/:page?" component={ ReplaysApp }/>
        <Route path="/counter" component={ Counter }/>
        <Route path="/fetchdata/:startDateIndex?" component={ FetchData } />
        <Route path="/upload" component={ UploadReplay } />
    </Layout>);