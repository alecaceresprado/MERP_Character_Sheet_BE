import express = require("express");

import { classController } from "./class";

const baseRouter: express.Router = express.Router();

baseRouter.use("/class", classController);

export { baseRouter };
