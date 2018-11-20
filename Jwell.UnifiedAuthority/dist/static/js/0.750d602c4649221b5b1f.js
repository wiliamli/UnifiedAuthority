webpackJsonp([0], {
    "1iOd": function (e, t) { },
    HTfV: function (e, t) { },
    d0ym: function (e, t, a) {
        "use strict";
        Object.defineProperty(t, "__esModule", {
            value: !0
        });
        var o = a("pFYg"),
            s = a.n(o),
            l = a("woOf"),
            n = a.n(l),
            r = a("u4Bs"),
            i = {
                data: function () {
                    var e = this;
                    return {
                        newRole: {
                            RoleName: "",
                            RoleCode: "",
                            Remark: ""
                        },
                        defaultData: {
                            ServiceNumber: "1",
                            CreatedBy: "admin",
                            CreatedTime: "2018-09-18T01:45:50.795Z",
                            ModifiedBy: "admin",
                            ModifiedTime: "2018-09-18T01:45:50.795Z"
                        },
                        loading: !1,
                        ruleRole: {
                            RoleName: [{
                                required: !0,
                                validator: function (t, a, o) {
                                    if ("" === a) return o(new Error("请填写角色中文名"));
                                    setTimeout(function () {
                                        e.$publicMethod.chineseOnly(a) ? o(new Error("中文名只能输入中文字符")) : o()
                                    },
                                        500)
                                },
                                trigger: "blur"
                            }],
                            RoleCode: [{
                                required: !0,
                                validator: function (t, a, o) {
                                    if ("" === a) return o(new Error("请填写角色英文名"));
                                    setTimeout(function () {
                                        e.$publicMethod.noSpecialCharacter(a) ? o(new Error("英文名只能输入数字和字母")) : o()
                                    },
                                        500)
                                },
                                trigger: "blur"
                            }]
                        }
                    }
                },
                methods: {
                    handleSubmit: function (e) {
                        var t = this;
                        this.loading = !0,
                            this.$refs[e].validate(function (e) {
                                e ? (t.newRole.Remark && "" !== t.newRole.Remark || (t.newRole.Remark = "——"), n()(t.newRole, t.defaultData), Object(r.k)("/Role/Save", t.newRole).then(function (e) {
                                    console.log("成功", e),
                                        200 === e.status && e.data.Success ? (t.$Message.success("角色创建成功!"), t.$emit("reGetList"), t.newRole = {},
                                            t.$emit("closeModal")) : t.$Message.error("创建角色失败!"),
                                        t.loading = !1
                                }).
                                    catch(function (e) {
                                        console.log("失败", e),
                                            t.$Message.error("创建角色失败!"),
                                            t.loading = !1
                                    })) : (t.$Message.error("请输入正确的信息!"), t.loading = !1)
                            })
                    },
                    handleReset: function (e) {
                        this.$refs[e].resetFields()
                    }
                }
            },
            c = {
                render: function () {
                    var e = this,
                        t = e.$createElement,
                        a = e._self._c || t;
                    return a("div", {
                        staticClass: "createRoleContainer"
                    },
                        [a("Form", {
                            ref: "newRole",
                            attrs: {
                                model: e.newRole,
                                rules: e.ruleRole,
                                "label-width": 60
                            }
                        },
                            [a("FormItem", {
                                attrs: {
                                    label: "中文名",
                                    prop: "RoleName"
                                }
                            },
                                [a("Input", {
                                    attrs: {
                                        placeholder: "请输入角色中文名"
                                    },
                                    model: {
                                        value: e.newRole.RoleName,
                                        callback: function (t) {
                                            e.$set(e.newRole, "RoleName", t)
                                        },
                                        expression: "newRole.RoleName"
                                    }
                                })], 1), e._v(" "), a("FormItem", {
                                    attrs: {
                                        label: "英文名",
                                        prop: "RoleCode"
                                    }
                                },
                                    [a("Input", {
                                        attrs: {
                                            placeholder: "请输入角色英文名"
                                        },
                                        model: {
                                            value: e.newRole.RoleCode,
                                            callback: function (t) {
                                                e.$set(e.newRole, "RoleCode", t)
                                            },
                                            expression: "newRole.RoleCode"
                                        }
                                    })], 1), e._v(" "), a("FormItem", {
                                        attrs: {
                                            label: "备注",
                                            prop: "Remark"
                                        }
                                    },
                                        [a("Input", {
                                            staticClass: "roleText",
                                            attrs: {
                                                type: "textarea",
                                                autosize: {
                                                    minRows: 2,
                                                    maxRows: 5
                                                },
                                                placeholder: "请对角色添加描述"
                                            },
                                            model: {
                                                value: e.newRole.Remark,
                                                callback: function (t) {
                                                    e.$set(e.newRole, "Remark", t)
                                                },
                                                expression: "newRole.Remark"
                                            }
                                        })], 1), e._v(" "), a("FormItem", {
                                            staticClass: "roleBtn"
                                        },
                                            [a("Button", {
                                                attrs: {
                                                    type: "primary",
                                                    loading: e.loading
                                                },
                                                on: {
                                                    click: function (t) {
                                                        e.handleSubmit("newRole")
                                                    }
                                                }
                                            },
                                                [e.loading ? a("span", [e._v("加载中...")]) : a("span", [e._v("保存")])]), e._v(" "), a("Button", {
                                                    staticClass: "roleCancle",
                                                    on: {
                                                        click: function (t) {
                                                            e.handleReset("newRole")
                                                        }
                                                    }
                                                },
                                                    [e._v("重置")])], 1)], 1)], 1)
                },
                staticRenderFns: []
            };
        var u = a("VU/8")(i, c, !1,
            function (e) {
                a("HTfV")
            },
            "data-v-55635781", null).exports,
            d = {
                data: function () {
                    var e = this;
                    return {
                        loading: !1,
                        userManageColumns: [{
                            type: "selection",
                            width: 60,
                            align: "center"
                        },
                        {
                            title: "序号",
                            key: "Index",
                            type: "index",
                            align: "center",
                            width: 150
                        },
                        {
                            title: "工号",
                            key: "EmployeeID",
                            align: "center"
                        },
                        {
                            title: "姓名",
                            key: "Name",
                            align: "center"
                        },
                        {
                            title: "部门",
                            key: "Department",
                            align: "center"
                        },
                        {
                            title: "操作",
                            key: "action",
                            align: "center",
                            render: function (t, a) {
                                return a.row._disabled ? t("div", [t("Button", {
                                    props: {
                                        type: "text",
                                        size: "small"
                                    },
                                    on: {
                                        click: function () {
                                            e.dissolveRelationship(a.row.EmployeeID, a.row.RoleID)
                                        }
                                    }
                                },
                                    "关系删除")]) : t("div", [])
                            }
                        }],
                        userManageData: [],
                        totalCount: Number,
                        pageIndex: Number,
                        userSearch: {
                            signNum: "",
                            userName: "",
                            department: "",
                            userState: ""
                        },
                        saveEmployee: [],
                        delData: {
                            serviceNumber: "1",
                            employeeID: "",
                            roleId: ""
                        },
                        selectData: []
                    }
                },
                props: {
                    employeeList: Array,
                    employAllData: Object
                },
                methods: {
                    searchTip: function () {
                        this.$emit("getEmployee", this.userSearch)
                    },
                    dissolveRelationship: function (e, t) {
                        var a = this;
                        this.delData.employeeID = e,
                            this.delData.roleId = t,
                            Object(r.c)("/Role/DeleteEmployeeRoleRelation", this.delData).then(function (e) {
                                console.log("成功", e),
                                    200 === e.status && e.data.Success ? (a.$Message.success("员工关系解除成功！"), a.$emit("getEmployee")) : a.$Message.error("员工关系解除失败！")
                            }).
                                catch(function (e) {
                                    console.log("失败", e),
                                        a.$Message.error("员工关系解除失败！")
                                })
                    },
                    selectRow: function (e) {
                        this.selectData = e
                    },
                    pageChange: function (e) {
                        this.$emit("getEmployee", e)
                    },
                    handleSubmit: function () {
                        var e = this;
                        for (var t in this.selectData) {
                            var a = {
                                ServiceNumber: "1",
                                EmployeeID: this.selectData[t].EmployeeID,
                                RoleID: this.selectData[t].RoleID,
                                CreatedBy: "string",
                                //CreatedTime: "2018-10-08T01:17:00.076Z",
                                ModifiedBy: "string"
                                //ModifiedTime: "2018-10-08T01:17:00.076Z"
                            };
                            this.saveEmployee.push(a)
                        }
                        Object(r.i)("/Role/SaveEmployeeRole", this.saveEmployee).then(function (t) {
                            console.log("成功", t),
                                200 === t.status && t.data.Success ? (e.$Message.success("关系保存成功!"), e.$emit("closeModal")) : e.$Message.error("关系保存失败!"),
                                e.loading = !1
                        }).
                            catch(function (t) {
                                console.log("失败", t),
                                    e.$Message.error("关系保存失败!"),
                                    e.loading = !1
                            })
                    },
                    handleReset: function () {
                        console.log("取消"),
                            this.$emit("closeModal")
                    },
                    getList: function () {
                        for (var e in this.userManageData = this.employeeList,
                            this.userManageData) this.userManageData[e].IsChecked && (this.userManageData[e]._disabled = !0, this.userManageData[e]._checked = !0)
                    },
                    getPage: function () {
                        this.totalCount = this.employAllData.TotalCount,
                            this.pageIndex = this.employAllData.PageIndex
                    }
                },
                watch: {
                    employeeList: function () {
                        this.getList(),
                            this.getPage()
                    }
                },
                created: function () {
                    this.getList(),
                        this.getPage()
                }
            },
            m = {
                render: function () {
                    var e = this,
                        t = e.$createElement,
                        a = e._self._c || t;
                    return a("div", {
                        staticClass: "userManageContainer"
                    },
                        [a("Form", {
                            staticClass: "userSearch",
                            attrs: {
                                model: e.userSearch,
                                "label-width": 40
                            }
                        },
                            [a("FormItem", {
                                attrs: {
                                    label: "工号"
                                }
                            },
                                [a("Input", {
                                    model: {
                                        value: e.userSearch.signNum,
                                        callback: function (t) {
                                            e.$set(e.userSearch, "signNum", t)
                                        },
                                        expression: "userSearch.signNum"
                                    }
                                })], 1), e._v(" "), a("FormItem", {
                                    attrs: {
                                        label: "姓名"
                                    }
                                },
                                    [a("Input", {
                                        model: {
                                            value: e.userSearch.userName,
                                            callback: function (t) {
                                                e.$set(e.userSearch, "userName", t)
                                            },
                                            expression: "userSearch.userName"
                                        }
                                    })], 1), e._v(" "), a("FormItem", {
                                        attrs: {
                                            label: "部门"
                                        }
                                    },
                                        [a("Input", {
                                            model: {
                                                value: e.userSearch.department,
                                                callback: function (t) {
                                                    e.$set(e.userSearch, "department", t)
                                                },
                                                expression: "userSearch.department"
                                            }
                                        })], 1), e._v(" "), a("FormItem", {
                                            attrs: {
                                                label: "状态"
                                            }
                                        },
                                            [a("Select", {
                                                model: {
                                                    value: e.userSearch.userState,
                                                    callback: function (t) {
                                                        e.$set(e.userSearch, "userState", t)
                                                    },
                                                    expression: "userSearch.userState"
                                                }
                                            },
                                                [a("Option", {
                                                    attrs: {
                                                        value: "0",
                                                        selected: ""
                                                    }
                                                },
                                                    [e._v("0")]), e._v(" "), a("Option", {
                                                        attrs: {
                                                            value: "1"
                                                        }
                                                    },
                                                        [e._v("1")])], 1)], 1), e._v(" "), a("FormItem", {
                                                            staticClass: "userSearchBtn"
                                                        },
                                                            [a("Button", {
                                                                attrs: {
                                                                    icon: "ios-search"
                                                                },
                                                                on: {
                                                                    click: e.searchTip
                                                                }
                                                            },
                                                                [e._v("查询")])], 1)], 1), e._v(" "), a("div", {
                                                                    staticClass: "userManageTable"
                                                                },
                                                                    [a("Table", {
                                                                        ref: "selection",
                                                                        staticClass: "userTableMain",
                                                                        attrs: {
                                                                            border: "",
                                                                            stripe: "",
                                                                            columns: e.userManageColumns,
                                                                            data: e.userManageData,
                                                                            size: "small"
                                                                        },
                                                                        on: {
                                                                            "on-selection-change": e.selectRow
                                                                        }
                                                                    }), e._v(" "), a("div", {
                                                                        staticStyle: {
                                                                            margin: "10px",
                                                                            overflow: "hidden"
                                                                        }
                                                                    },
                                                                        [a("div", {
                                                                            staticStyle: {
                                                                                float: "right"
                                                                            }
                                                                        },
                                                                            [a("Page", {
                                                                                attrs: {
                                                                                    total: e.totalCount,
                                                                                    current: e.pageIndex
                                                                                },
                                                                                on: {
                                                                                    "on-change": e.pageChange
                                                                                }
                                                                            })], 1)])], 1), e._v(" "), a("div", {
                                                                                staticClass: "userBtn"
                                                                            },
                                                                                [a("Button", {
                                                                                    attrs: {
                                                                                        type: "primary",
                                                                                        loading: e.loading
                                                                                    },
                                                                                    on: {
                                                                                        click: e.handleSubmit
                                                                                    }
                                                                                },
                                                                                    [e.loading ? a("span", [e._v("加载中...")]) : a("span", [e._v("保存")])]), e._v(" "), a("Button", {
                                                                                        on: {
                                                                                            click: e.handleReset
                                                                                        }
                                                                                    },
                                                                                        [e._v("取消")])], 1)], 1)
                },
                staticRenderFns: []
            };
        var p = {
            data: function () {
                var e = this;
                return {
                    serviceData: {
                        serviceNumber: "1"
                    },
                    getEmployeeData: {
                        ServiceNumber: "1",
                        RoleCode: "",
                        EmployeeID: "",
                        Name: "",
                        Department: "",
                        Status: 0,
                        PageIndex: 1,
                        PageSize: 10,
                        Sort: "id",
                        SortDirection: 0
                    },
                    userListColumns: [{
                        title: "序号",
                        key: "Index",
                        type: "index",
                        align: "center",
                        width: 150
                    },
                    {
                        title: "角色名称",
                        key: "RoleName",
                        align: "center"
                    },
                    {
                        title: "备注",
                        key: "Remark",
                        align: "center"
                    },
                    {
                        title: "操作",
                        key: "action",
                        align: "center",
                        render: function (t, a) {
                            return t("div", [t("Button", {
                                props: {
                                    type: "text",
                                    size: "small"
                                },
                                on: {
                                    click: function () {
                                        e.openManageUsers(a.row.RoleName, a.row.RoleCode)
                                    }
                                }
                            },
                                "管理用户"), t("Button", {
                                    props: {
                                        type: "text",
                                        size: "small"
                                    },
                                    on: {
                                        click: function () {
                                            e.delRole(a.row)
                                        }
                                    }
                                },
                                    "删除角色")])
                        }
                    }],
                    userListData: [],
                    employeeList: [],
                    openUserModal: !1,
                    manageUsers: !1,
                    thisRole: "",
                    largeWidth: 40,
                    employAllData: null
                }
            },
            methods: {
                getRoleData: function () {
                    var e = this;
                    console.log("GetEmployeeRoles", this.serviceData);
                    Object(r.m)("/Role/GetEmployeeRoles", this.serviceData).then(function (t) {
                        console.log("成功", t),
                            200 === t.status && t.data.Success ? e.userListData = t.data.Data : e.$Message.error("获取角色列表失败，请再试！")
                    }).
                        catch(function (t) {
                            console.log("失败", t),
                                e.$Message.error("获取角色列表失败，请再试！")
                        })
                },
                getEmployeeDataByRole: function (e) {
                    var t = this;
                    e ? ("object" === (void 0 === e ? "undefined" : s()(e)) ? (this.getEmployeeData.EmployeeID = e.signNum, this.getEmployeeData.Department = e.department, this.getEmployeeData.Name = e.userName, this.getEmployeeData.Status = e.userState) : this.getEmployeeData.PageIndex = e, Object(r.d)("/EmployeeInfo/GetEmployeeInfoWithRole", this.getEmployeeData).then(function (e) {
                        console.log("成功", e),
                            200 === e.status && e.data.Success ? (t.employeeList = e.data.Data.Pager, t.employAllData = e.data.Data) : t.$Message.error("请重试！")
                    }).
                        catch(function (e, a) {
                            console.log("失败", e),
                                t.$Message.error("请重试！")
                        })) : (this.getEmployeeData.Department = "", this.getEmployeeData.Name = "", this.getEmployeeData.Status = "", Object(r.d)("/EmployeeInfo/GetEmployeeInfoWithRole", this.getEmployeeData).then(function (e) {
                            console.log("成功", e),
                                200 === e.status && e.data.Success ? (t.employeeList = e.data.Data.Pager, t.employAllData = e.data.Data, t.manageUsers = !0, t.largeWidth = 80, t.openUserModal = !0) : t.$Message.error("未成功获取此角色下员工关系，请再试！")
                        }).
                            catch(function (e, a) {
                                console.log("失败", e),
                                    t.$Message.error("未成功获取此角色下员工关系，请再试！")
                            }))
                },
                openCreateRole: function () {
                    this.manageUsers = !1,
                        this.largeWidth = 40,
                        this.openUserModal = !0
                },
                openManageUsers: function (e, t) {
                    this.thisRole = e,
                        this.getEmployeeData.RoleCode = t,
                        this.getEmployeeDataByRole()
                },
                closeModal: function () {
                    this.openUserModal = !1,
                        this.manageUsers = !1,
                        this.largeWidth = 40
                },
                delRole: function (e) {
                    var t = this;
                    console.log(e);
                    var a = {
                        serviceNumber: e.ServiceNumber,
                        roleCode: e.RoleCode
                    };
                    Object(r.b)("/Role/DeleteRole", a).then(function (e) {
                        console.log("成功", e),
                            200 === e.status && e.data.Success ? (t.$Message.success("删除角色成功"), t.getRoleData()) : t.$Message.error("删除角色失败，请再试！")
                    }).
                        catch(function (e) {
                            console.log("失败", e),
                                t.$Message.error("删除角色失败，请再试！")
                        })
                }
            },
            components: {
                createModal: u,
                manageModal: a("VU/8")(d, m, !1,
                    function (e) {
                        a("gDm1")
                    },
                    "data-v-2450cd65", null).exports
            },
            beforeCreate: function () {
                console.log(this.$route.params.sign)
            },
            created: function () {
                this.getRoleData()
            }
        },
            g = {
                render: function () {
                    var e = this,
                        t = e.$createElement,
                        a = e._self._c || t;
                    return a("div", {
                        staticClass: "userContainer"
                    },
                        [a("header", [a("Breadcrumb", {
                            staticClass: "menuBread"
                        },
                            [a("BreadcrumbItem", {
                                attrs: {
                                    to: "/"
                                }
                            },
                                [a("Icon", {
                                    attrs: {
                                        type: "ios-home"
                                    }
                                }), e._v(" 系统首页\n        ")], 1), e._v(" "), a("BreadcrumbItem", [a("Icon", {
                                    attrs: {
                                        type: "ios-contacts"
                                    }
                                }), e._v(" 用户管理\n        ")], 1)], 1), e._v(" "), a("Button", {
                                    attrs: {
                                        type: "primary",
                                        icon: "md-add"
                                    },
                                    on: {
                                        click: e.openCreateRole
                                    }
                                },
                                    [e._v("创建角色")])], 1), e._v(" "), a("Table", {
                                        staticClass: "userTable",
                                        attrs: {
                                            border: "",
                                            stripe: "",
                                            columns: e.userListColumns,
                                            data: e.userListData
                                        }
                                    }), e._v(" "), a("div", {
                                        staticStyle: {
                                            margin: "10px",
                                            overflow: "hidden"
                                        }
                                    },
                                        [a("div", {
                                            staticStyle: {
                                                float: "right"
                                            }
                                        },
                                            [a("Page", {
                                                attrs: {
                                                    total: 100,
                                                    current: 1
                                                }
                                            })], 1)]), e._v(" "), a("Modal", {
                                                attrs: {
                                                    title: "创建角色",
                                                    "footer-hide": "",
                                                    styles: {
                                                        top: "15px"
                                                    },
                                                    width: e.largeWidth
                                                },
                                                model: {
                                                    value: e.openUserModal,
                                                    callback: function (t) {
                                                        e.openUserModal = t
                                                    },
                                                    expression: "openUserModal"
                                                }
                                            },
                                                [e.manageUsers ? a("div", {
                                                    attrs: {
                                                        slot: "header"
                                                    },
                                                    slot: "header"
                                                },
                                                    [a("Breadcrumb", {
                                                        staticClass: "menuBread"
                                                    },
                                                        [a("BreadcrumbItem", [a("Icon", {
                                                            attrs: {
                                                                type: "ios-contact"
                                                            }
                                                        }), e._v(" " + e._s(e.thisRole) + "\n            ")], 1), e._v(" "), a("BreadcrumbItem", [a("Icon", {
                                                            attrs: {
                                                                type: "ios-contacts"
                                                            }
                                                        }), e._v(" 管理用户\n            ")], 1)], 1)], 1) : e._e(), e._v(" "), e.manageUsers ? a("manageModal", {
                                                            attrs: {
                                                                employeeList: e.employeeList,
                                                                employAllData: e.employAllData
                                                            },
                                                            on: {
                                                                closeModal: e.closeModal,
                                                                getEmployee: e.getEmployeeDataByRole
                                                            }
                                                        }) : a("createModal", {
                                                            on: {
                                                                closeModal: e.closeModal,
                                                                reGetList: e.getRoleData
                                                            }
                                                        })], 1)], 1)
                },
                staticRenderFns: []
            };
        var h = a("VU/8")(p, g, !1,
            function (e) {
                a("1iOd")
            },
            "data-v-ff126f56", null);
        t.
            default = h.exports
    },
    gDm1: function (e, t) { }
});
//# sourceMappingURL=0.750d602c4649221b5b1f.js.map
