import * as functions from "firebase-functions";
import express = require("express");

import { baseRouter } from "./router";

const app: express.Application = express();

app.use("/api", baseRouter);

exports.app = functions.https.onRequest(app);
