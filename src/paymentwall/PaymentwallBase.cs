﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Paymentwall
{
    public abstract class PaymentwallBase
    {
        protected PaymentwallBase()
        {
            AppKey = PaymentwallSettings.Default.AppKey;
            SecretKey = PaymentwallSettings.Default.SecretKey;
            ProApiKey = PaymentwallSettings.Default.ProApiKey;
        }

        /*
         * Paymentwall library version
         */
        const string LIB_VERSION = "1.0.0";

        /*
         * URLs for Paymentwall Pro
         */
        protected const string CHARGE_URL = "https://api.paymentwall.com/api/pro/v1/charge";
        protected const string SUBS_URL = "https://api.paymentwall.com/api/pro/v1/subscription";

        /*
         * Controllers for APIs
         */
        protected const string CONTROLLER_PAYMENT_VIRTUAL_CURRENCY = "ps";
        protected const string CONTROLLER_PAYMENT_DIGITAL_GOODS = "subscription";
        protected const string CONTROLLER_PAYMENT_CART = "cart";

        /**
	     * Signature versions
	     */
        protected const int DEFAULT_SIGNATURE_VERSION = 3;
        protected const int SIGNATURE_VERSION_1 = 1;
        protected const int SIGNATURE_VERSION_2 = 2;
        protected const int SIGNATURE_VERSION_3 = 3;

        protected List<string> errors = new List<string>();

        /**
         * Paymentwall application key - can be found in your merchant area
         * @param string appKey
         */
        public string AppKey { get; set; }

        /**
         * Paymentwall secret key - can be found in your merchant area
         * @param string secretKey
         */
        public string SecretKey { get; set; }

        /**
         * Paymentwall Pro API Key
         * @param string proApiKey
         */
        public string ProApiKey { get; set; }

        /*
         * Fill the array with the errors found at execution
         * 
         * @param string err
         * @return int
         */
        protected int appendToErrors(string err)
        {
            this.errors.Add(err);
            return this.errors.Count;
        }

        /**
         * Return errors
         * 
         * @return List<string>
         */
        public List<string> getErrors()
        {
            return this.errors;
        }

        /*
         * Return error summary
         * 
         * @return string
         */
        public string getErrorSummary()
        {
            return string.Join("\n", this.getErrors());
        }

    }
}