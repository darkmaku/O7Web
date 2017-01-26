// O7ERP Web created by felix_dev
using System.Collections.Generic;
using Angkor.O7Framework.Common.Model;
using Angkor.O7Framework.Data.Tool;
using Angkor.O7Framework.Infrastructure.Data;
using Angkor.O7Web.Common.Finantial.Entity;
using Angkor.O7Web.Data.Finantial.DataMapper;

namespace Angkor.O7Web.Data.Finantial
{
    public class FinantialDataService : O7AbstractData
    {
        public FinantialDataService(string user, string password) : base(user, password)
        {
        }

        public virtual List<InvoiceDocumentType> DocumentTypes()
        {
            return DataAccess.ExecuteFunction<InvoiceDocumentType>("finantial_invoice.document_type", O7DbParameterCollection.Make, InvoiceDocumentTypeMapper.Class);
        }

        public virtual bool AddSeries(string companyId, string branchId, string documentType, string id, string current,
            string max, string min, string @default, string digital)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_company", companyId));
            parameters.Add(O7Parameter.Make("p_branch", branchId));
            parameters.Add(O7Parameter.Make("p_document_type", documentType));
            parameters.Add(O7Parameter.Make("p_id", id));
            parameters.Add(O7Parameter.Make("p_current", current));
            parameters.Add(O7Parameter.Make("p_max", max));
            parameters.Add(O7Parameter.Make("p_min", min));
            parameters.Add(O7Parameter.Make("p_default", @default));
            parameters.Add(O7Parameter.Make("p_digital", digital));
            return DataAccess.ExecuteFunction<int>("O7EXPRESS_PACKAGE_SERIESF.get_seriesF", parameters) == 1;
        }

        public virtual int AddInvoice(string companyId, string branchId, 
                                       string documentType, string serie, 
                                       string currency,string documentDate, 
                                       string documentExpiration,string clienteCode
                                       ,string codTax,string clientName
                                       ,string invoiceAddress,string clientId,string glosa,
                                       string sellType,string language,
                                       string condSell,string payment,
                                       string bussinessline,string finantialcod,
                                       string telephone,string seller,
                                       string employeeId,string perception,
                                       string donate,string documentTypeRef,
                                       string documentIdRef,string documentOC,
                                       string guiRem,string addressId, 
                                       string serieExtRef,string nroExtRef)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_cia", companyId));
            parameters.Add(O7Parameter.Make("p_suc", branchId));
            parameters.Add(O7Parameter.Make("p_tipo_doc", documentType));
            parameters.Add(O7Parameter.Make("p_serie_ext", serie));
            parameters.Add(O7Parameter.Make("p_moneda", currency));
            parameters.Add(O7Parameter.Make("p_fecha_doc", documentDate));
            parameters.Add(O7Parameter.Make("p_fecha_vto", documentExpiration));
            parameters.Add(O7Parameter.Make("p_codcli", clienteCode));
            parameters.Add(O7Parameter.Make("p_cod_imp_afec", codTax));
            parameters.Add(O7Parameter.Make("p_razon_social", clientName));
            parameters.Add(O7Parameter.Make("p_dir_fact", invoiceAddress));
            parameters.Add(O7Parameter.Make("p_nro_ruc", clientId));
            parameters.Add(O7Parameter.Make("p_glosa", glosa));
            parameters.Add(O7Parameter.Make("p_tipo_venta", sellType));
            parameters.Add(O7Parameter.Make("p_cod_idioma", language));
            parameters.Add(O7Parameter.Make("p_cond_venta", condSell));
            parameters.Add(O7Parameter.Make("p_forma_pago", payment));
            parameters.Add(O7Parameter.Make("p_linea_negocio", bussinessline));
            parameters.Add(O7Parameter.Make("p_cod_financiero", finantialcod));
            parameters.Add(O7Parameter.Make("p_nro_telefono", telephone));
            parameters.Add(O7Parameter.Make("p_cod_vendedor", seller));
            parameters.Add(O7Parameter.Make("p_cod_trabajador", employeeId));
            parameters.Add(O7Parameter.Make("p_doc_flag_out", "N"));
            parameters.Add(O7Parameter.Make("p_porc_perc", perception));
            parameters.Add(O7Parameter.Make("p_donacion", donate));
            parameters.Add(O7Parameter.Make("p_doc_ref_1", documentTypeRef));
            parameters.Add(O7Parameter.Make("p_doc_ref_2", documentIdRef));
            parameters.Add(O7Parameter.Make("p_nro_oc", documentOC));
            parameters.Add(O7Parameter.Make("p_nro_gui_rem", guiRem));
            parameters.Add(O7Parameter.Make("p_coddir", addressId));
            parameters.Add(O7Parameter.Make("p_serdoceref", serieExtRef));
            parameters.Add(O7Parameter.Make("p_nrodoceref", nroExtRef));
            return DataAccess.ExecuteFunction<int>("finantial_invoice.insert_cab_factura", parameters);
        }

        public virtual bool AddInvoiceDetail(
                                    string companyId, string branchId,
                                    string documentType,string documentId,
                                    string conceptId,string observacion,
                                    string cantidad,string unitValue,
                                    string taxId,string perception,
                                    string ccoId
                                                )
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_cia", companyId));
            parameters.Add(O7Parameter.Make("p_suc", branchId));
            parameters.Add(O7Parameter.Make("p_tipdoc", documentType));
            parameters.Add(O7Parameter.Make("p_nrodoc", documentId));
            parameters.Add(O7Parameter.Make("p_cod_concepto", conceptId));
            parameters.Add(O7Parameter.Make("p_observacion", observacion));
            parameters.Add(O7Parameter.Make("p_cantidad", cantidad));
            parameters.Add(O7Parameter.Make("p_val_unit", unitValue));
            parameters.Add(O7Parameter.Make("p_cod_imp", taxId));
            parameters.Add(O7Parameter.Make("p_perc", perception));
            parameters.Add(O7Parameter.Make("p_cen_cos", ccoId));
            return DataAccess.ExecuteFunction<int>("finantial_invoice.insert_row_det_factura", parameters)==1;
        }

        public virtual List<InvoiceDocumentCount> AllSeries(string companyId, string branchId)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_company", companyId));
            parameters.Add(O7Parameter.Make("p_branch", branchId));            
            return DataAccess.ExecuteFunction<InvoiceDocumentCount>("O7EXPRESS_PACKAGE_SERIESF.get_seriesF", parameters, InvoiceDocumentCountMapper.Class);
        }

        public virtual List<InvoiceEdit> GetInvoice(string companyId, string branchId,string documentType,string documentId)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_cia", companyId));
            parameters.Add(O7Parameter.Make("p_suc", branchId));
            parameters.Add(O7Parameter.Make("p_tipo_doc", documentType));
            parameters.Add(O7Parameter.Make("p_nro_doc", documentId));
            return DataAccess.ExecuteFunction<InvoiceEdit>("finantial_invoice.search_fact", parameters, InvoiceMapper.Class);
        }

        public virtual List<InvoiceDetail> GetInvoiceDetail(string companyId, string branchId, string documentType, string documentId)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_cia", companyId));
            parameters.Add(O7Parameter.Make("p_suc", branchId));
            parameters.Add(O7Parameter.Make("p_tipo_doc", documentType));
            parameters.Add(O7Parameter.Make("p_nro_doc", documentId));
            return DataAccess.ExecuteFunction<InvoiceDetail>("finantial_invoice.search_fact_detail", parameters, InvoiceDetailMapper.Class);
        }


        public virtual List<ClientDefaultValues> ClientDefaultValues(string companyId, string branchId,string clientCode)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_cia", companyId));
            parameters.Add(O7Parameter.Make("p_suc", branchId));
            parameters.Add(O7Parameter.Make("p_codcli", clientCode));
            return DataAccess.ExecuteFunction<ClientDefaultValues>("finantial_invoice.confirm_client", parameters, ClientDefaultValueMapper.Class);
        }

        public virtual List<InvoiceSeries> Series(string companyId, string branchId, string docType)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_cia", companyId));
            parameters.Add(O7Parameter.Make("p_suc", branchId));
            parameters.Add(O7Parameter.Make("p_tip_doc", docType));
            return DataAccess.ExecuteFunction<InvoiceSeries>("finantial_invoice.serie_ext_type", parameters, InvoiceSeriesMapper.Class);
        }

        public virtual List<SingleValue> DocumentInformation(string companyId, string branchId, string docType)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_cia", companyId));
            parameters.Add(O7Parameter.Make("p_suc", branchId));
            parameters.Add(O7Parameter.Make("p_tip_doc", docType));
            return DataAccess.ExecuteFunction<SingleValue>("finantial_invoice.confirm_doc", parameters, SingleValueMapper.Class);
        }

        public virtual List<SingleValue> GetFecVto(string companyId, string branchId, string payment, string documentDate)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_cia", companyId));
            parameters.Add(O7Parameter.Make("p_suc", branchId));
            parameters.Add(O7Parameter.Make("p_fecha", documentDate));
            parameters.Add(O7Parameter.Make("p_cod_forp", payment));
            return DataAccess.ExecuteFunction<SingleValue>("finantial_invoice.calcular_fecha_vto", parameters, SingleValueMapper.Class);
        }


        public virtual List<InvoiceClient> AllClients(string companyId, string branchId, string word)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_cia", companyId));
            parameters.Add(O7Parameter.Make("p_suc", branchId));
            parameters.Add(O7Parameter.Make("p_cadena", word));
            return DataAccess.ExecuteFunction<InvoiceClient>("finantial_invoice.search_client", parameters, InvoiceClientMapper.Class);
        }

        public virtual bool GeneratePDF(string companyId, string branchId, string documentType, string documentId)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_cia", companyId));
            parameters.Add(O7Parameter.Make("p_suc", branchId));
            parameters.Add(O7Parameter.Make("p_tipdoc", documentType));
            parameters.Add(O7Parameter.Make("p_nrodoc", documentId));

            HeadInvoicePDF head =
                DataAccess.ExecuteFunction<HeadInvoicePDF>("finantial_invoice.head_pdf", parameters,
                    HeadInvoicePDFMapper.Class)[0];
            
            List<DetailInvoicePDF> details = DataAccess.ExecuteFunction<DetailInvoicePDF>("finantial_invoice.detail_pdf", parameters, DetailInvoicePDFMapper.Class);

            return PdfGenerator.generar(head, details,"./Factura.pdf");

        }


        public virtual List<InvoiceBasicInformation> AllInvoices(string companyId, string branchId, string pFilter)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_cia", companyId));
            parameters.Add(O7Parameter.Make("p_suc", branchId));
            parameters.Add(O7Parameter.Make("p_filter", pFilter));
            return DataAccess.ExecuteFunction<InvoiceBasicInformation>("finantial_invoice.invoices", parameters, InvoiceBasicInformationMapper.Class);
        }
   
        public virtual List<InvoiceTypeAhead> AllConcepts(string companyId, string branchId, string ratePerception)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_cia", companyId));
            parameters.Add(O7Parameter.Make("p_suc", branchId));
            parameters.Add(O7Parameter.Make("p_tasper", ratePerception));
            return DataAccess.ExecuteFunction<InvoiceTypeAhead>("finantial_invoice.search_concept_product", parameters, TypeAheadMapper.Class);
        }

     

        public virtual List<GenericListValue> AllCondSells()
        {
            var parameters = O7DbParameterCollection.Make;
            return DataAccess.ExecuteFunction<GenericListValue>("finantial_invoice.cond_vta_type", parameters, InvoiceGenericListMapper.Class);
        }

        public virtual List<GenericListValue> AllSellsTypes()
        {
            var parameters = O7DbParameterCollection.Make;
            return DataAccess.ExecuteFunction<GenericListValue>("finantial_invoice.tip_vta_type", parameters, InvoiceGenericListMapper.Class);
        }

        public virtual List<GenericListValue> AllPayements(string cond_vta_code)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_convta", cond_vta_code));
            return DataAccess.ExecuteFunction<GenericListValue>("finantial_invoice.form_pago_type", parameters, InvoiceGenericListMapper.Class);
        }
        //cod finan linneg  vendedor
        public virtual List<GenericListValue> AllFinantialCodes()
        {
            var parameters = O7DbParameterCollection.Make;
            return DataAccess.ExecuteFunction<GenericListValue>("finantial_invoice.cod_fin_type", parameters, InvoiceGenericListMapper.Class);
        }

        public virtual List<GenericListValue> AllBusinessLines(string companyId, string branchId)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_cia", companyId));
            parameters.Add(O7Parameter.Make("p_suc", branchId));
            return DataAccess.ExecuteFunction<GenericListValue>("finantial_invoice.lin_neg_type", parameters, InvoiceGenericListMapper.Class);

        }

        public virtual List<GenericListValue> AllSeller(string companyId, string branchId)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_cia", companyId));
            parameters.Add(O7Parameter.Make("p_suc", branchId));
            return DataAccess.ExecuteFunction<GenericListValue>("finantial_invoice.seller_type", parameters, InvoiceGenericListMapper.Class);

        }

        public virtual List<GenericListValue> AllDirFacs(string companyId, string branchId,string clientId)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_cia", companyId));
            parameters.Add(O7Parameter.Make("p_suc", branchId));
            parameters.Add(O7Parameter.Make("p_cliente", clientId));
            return DataAccess.ExecuteFunction<GenericListValue>("finantial_invoice.dirs_fac", parameters, InvoiceGenericListMapper.Class);

        }

        public virtual List<GenericListValue> AllCurrencies()
        {
            var parameters = O7DbParameterCollection.Make;
            return DataAccess.ExecuteFunction<GenericListValue>("finantial_invoice.money_type", parameters, InvoiceGenericListMapper.Class);

        }

        public virtual List<GenericListValue> AllLanguages()
        {
            var parameters = O7DbParameterCollection.Make;
            return DataAccess.ExecuteFunction<GenericListValue>("finantial_invoice.language_type", parameters, InvoiceGenericListMapper.Class);

        }

        public virtual List<GenericListValue> AllTaxes()
        {
            var parameters = O7DbParameterCollection.Make;
            return DataAccess.ExecuteFunction<GenericListValue>("finantial_invoice.tax_type", parameters, InvoiceGenericListMapper.Class);

        }

        public virtual List<GenericListValue> AllPerception()
        {
            var parameters = O7DbParameterCollection.Make;
            return DataAccess.ExecuteFunction<GenericListValue>("finantial_invoice.percep_type", parameters, InvoiceGenericListMapper.Class);

        }

        public virtual List<InvoiceTypeAhead> AllCco(string companyId,string branchId)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_cia", companyId));
            parameters.Add(O7Parameter.Make("p_suc", branchId));
            return DataAccess.ExecuteFunction<InvoiceTypeAhead>("finantial_invoice.search_cen_cos", parameters,TypeAheadMapper.Class);

        }

        public virtual int UpdateInvoiceHead(string companyId, string branchId,
                                        string documentType, string documentId,
                                       string currency, string documentDate,
                                       string documentExpiration, string clienteCode
                                       , string codTax, string porTax,string clientName
                                       , string invoiceAddress, string clientId, string glosa,
                                       string sellType, string language,
                                       string condSell, string payment,
                                       string bussinessline, string finantialcod,
                                       string telephone, string seller,
                                       string employeeId, string perception,
                                       string donate, string documentTypeRef,
                                       string documentIdRef, string documentOC,
                                       string guiRem, string addressId,
                                       string serieExtRef, string nroExtRef)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_cia", companyId));
            parameters.Add(O7Parameter.Make("p_suc", branchId));
            parameters.Add(O7Parameter.Make("p_tipo_doc", documentType));
            parameters.Add(O7Parameter.Make("p_nro_doc", documentId));
            parameters.Add(O7Parameter.Make("p_moneda", currency));
            parameters.Add(O7Parameter.Make("p_fecha_doc", documentDate));
            parameters.Add(O7Parameter.Make("p_fecha_vto", documentExpiration));
            parameters.Add(O7Parameter.Make("p_codcli", clienteCode));
            parameters.Add(O7Parameter.Make("p_cod_imp_afec", codTax));
            parameters.Add(O7Parameter.Make("p_por_imp_afec", porTax));
            parameters.Add(O7Parameter.Make("p_razon_social", clientName));
            parameters.Add(O7Parameter.Make("p_dir_fact", invoiceAddress));
            parameters.Add(O7Parameter.Make("p_nro_ruc", clientId));
            parameters.Add(O7Parameter.Make("p_glosa", glosa));
            parameters.Add(O7Parameter.Make("p_tipo_venta", sellType));
            parameters.Add(O7Parameter.Make("p_cod_idioma", language));
            parameters.Add(O7Parameter.Make("p_cond_venta", condSell));
            parameters.Add(O7Parameter.Make("p_forma_pago", payment));
            parameters.Add(O7Parameter.Make("p_linea_negocio", bussinessline));
            parameters.Add(O7Parameter.Make("p_cod_financiero", finantialcod));
            parameters.Add(O7Parameter.Make("p_nro_telefono", telephone));
            parameters.Add(O7Parameter.Make("p_cod_vendedor", seller));
            parameters.Add(O7Parameter.Make("p_cod_trabajador", employeeId));
            parameters.Add(O7Parameter.Make("p_porc_perc", perception));
            parameters.Add(O7Parameter.Make("p_donacion", donate));
            parameters.Add(O7Parameter.Make("p_doc_ref_1", documentTypeRef));
            parameters.Add(O7Parameter.Make("p_doc_ref_2", documentIdRef));
            parameters.Add(O7Parameter.Make("p_nro_oc", documentOC));
            parameters.Add(O7Parameter.Make("p_nro_gui_rem", guiRem));
            parameters.Add(O7Parameter.Make("p_coddir", addressId));
            parameters.Add(O7Parameter.Make("p_serdoceref", serieExtRef));
            parameters.Add(O7Parameter.Make("p_nrodoceref", nroExtRef));
            return DataAccess.ExecuteFunction<int>("finantial_invoice.update_invoice", parameters);

        }







    }
}