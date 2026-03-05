package authz

default allow := false

allow if {
    input.action == "view_concerts"
    role := input.user.role
    permission := data.roles[role][_]
    permission.action == input.action
    permission.resource == input.resource.type
}

allow if {
    input.action == "create_concert"
    role := input.user.role
    permission := data.roles[role][_]
    permission.action == input.action
    permission.resource == input.resource.type
}

allow if {
    input.action in {"delete_concert", "update_concert"}

    role := input.user.role
    permission := data.roles[role][_]
    permission.action == input.action
    permission.resource == input.resource.type

    input.user.id == input.resource.attributes.owner
}

allow if {
    input.action == "view_bookings"

    role := input.user.role
    permission := data.roles[role][_]
    permission.action == input.action
}

allowed_permissions contains permission if {
    role := input.user.role
    permission := data.roles[role][_]
}